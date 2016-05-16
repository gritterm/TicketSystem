'use strict';
app.controller('eventController', ['$routeParams', '$scope', 'eventsService',  
  function ($routeParams, $scope, eventsService) {
   var eventid = $routeParams.eventId;
   eventsService.getEvent(eventid).then(function(results){
        $scope.event = results.data;
   });   
}]);