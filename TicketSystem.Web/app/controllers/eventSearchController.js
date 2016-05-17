'use strict';
app.controller('eventSearchController', ['$scope', '$route', 'eventsService','eventTypesService', 'venuesService',
 function ($scope, $route,eventsService, eventTypesService, venuesService) {

    $scope.events = [];
    $scope.searchoptions = {};
    $scope.searchoptions.newEntityName = "New Event";
    $scope.eventTypes = [];

    $scope.searchoptions.columnDefs = [{
        name: 'Event_Name',
        cellTemplate:'<div>' +
                   '<a href="http://localhost:32150/#/Event/{{row.entity.Event_ID}}">{{row.entity.Event_Name}}</a>' +
                   '</div>'
    },
    {
        name: 'Venue_Name'
    },
    {
        name: 'Event_Type_Name'
    },
    {
        name: 'Event_Date'
    }];
    
    $scope.newEvent = {
    };
   


    $scope.saveEvent = saveEvent;

    $scope.searchoptions.newEntityAction = function(){
        $('#myModal').modal('show')
    };  
    eventTypesService.getEventTypes().then(function (results){
        $scope.eventTypes = results.data.value;
        $scope.selectedEventType = { value: $scope.eventTypes[0] };

    });

    venuesService.getVenues().then(function (results){
        $scope.venues = results.data.value;
        $scope.selectedVenue = { value: $scope.venues[0] };
    });
    eventsService.getEvents().then(function (results) {
        $scope.searchoptions.data = results.data.value;
        $scope.searchoptions.enableFiltering = true;     
    }, function (error) {
        //alert(error.data.message);
    });

    function saveEvent()
    {
        $scope.newEvent.Event_Type_ID = $scope.selectedEventType.value.Event_Type_ID;
        $scope.newEvent.Venue_ID = $scope.selectedVenue.value.Venue_ID;

        eventsService.newEvent($scope.newEvent).then(function(results) {
            $('#myModal').modal('hide')
            var event = results.data;
            window.location = 'http://localhost:32150/#/Event/' + event.Event_ID
        });
    }

}]);