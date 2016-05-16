'use strict';
app.controller('eventTypeSearchController', ['$scope', '$route', 'eventTypesService', function ($scope, $route,eventTypesService) {

    $scope.eventTypes = [];
    $scope.searchoptions = {};
    $scope.searchoptions.newEntityName = "New Event Type";
    $scope.searchoptions.columnDefs = [{
        name: 'Event_Type_Name',
        cellTemplate:'<div>' +
                   '<a href="http://localhost:32150/#/EventType/{{row.entity.Event_Type_ID}}">{{row.entity.Event_Type_Name}}</a>' +
                   '</div>'
    }
    ];
    
    $scope.newEventType = {
    };

    $scope.saveEventType = saveEventType;

    $scope.searchoptions.newEntityAction = function(){
        $('#myModal').modal('show')
    };  
    eventTypesService.getEventTypes().then(function (results) {
        $scope.searchoptions.data = results.data.value;
        $scope.searchoptions.enableFiltering = true;     
    }, function (error) {
        //alert(error.data.message);
    });

    function saveEventType()
    {
        eventTypesService.newEventType($scope.newEventType).then(function(results) {
            $('#myModal').modal('hide')
            var EventType = results.data;
            window.location = 'http://localhost:32150/#/EventType/' + eventType.Event_Type_ID
        });
    }

}]);