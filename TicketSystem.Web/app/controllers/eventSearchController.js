'use strict';
app.controller('eventSearchController', ['$scope', '$route', 'eventsService','eventTypesService',
 function ($scope, $route,eventsService, eventTypesService) {

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
        name: 'Customer_Email'
    },
    {
        name: 'Event_Type_name'
    },
    {
        name: 'Event_Date'
    }];
    
    $scope.newEvent = {
    };
    $scope.itemArray = [
        {id: 1, name: 'first'},
        {id: 2, name: 'second'},
        {id: 3, name: 'third'},
        {id: 4, name: 'fourth'},
        {id: 5, name: 'fifth'},
    ];

    $scope.selected = { value: $scope.itemArray[0] };
    $scope.saveEvent = saveEvent;

    $scope.searchoptions.newEntityAction = function(){
        $('#myModal').modal('show')
    };  
    eventTypesService.getEventTypes().then(function (results){
        $scope.eventTypes = results.data.value;
    })
    eventsService.getEvents().then(function (results) {
        $scope.searchoptions.data = results.data.value;
        $scope.searchoptions.enableFiltering = true;     
    }, function (error) {
        //alert(error.data.message);
    });

    function saveEvent()
    {
        eventsService.newEvent($scope.newEvent).then(function(results) {
            $('#myModal').modal('hide')
            var event = results.data;
            window.location = 'http://localhost:32150/#/Event/' + event.Event_ID
        });
    }

}]);