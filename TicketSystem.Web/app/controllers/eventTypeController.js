'use strict';
app.controller('eventTypeController', ['$routeParams', '$scope', 'eventTypesService', function ($routeParams, $scope, eventTypesService) {
   var eventTypeid = $routeParams.eventTypeId;
   eventTypesService.geteventType(eventTypeid).then(function(results){
        $scope.eventType = results.data;
   });   
}]);