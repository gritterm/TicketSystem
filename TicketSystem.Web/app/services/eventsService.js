'use strict';
app.factory('eventsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var eventsServiceFactory = {};

    var _getEvents = function () {

        return $http.get(serviceBase + 'odata/Events').then(function (results) {
            return results;
        });
    };
    var _getEvent = function (eventId) {
        return $http.get(serviceBase + 'odata/Events/?key=' + eventId).then(function(results){
            return results;
        });
    };
    var _newEvent = function(newEvent)
    {
      return $http.post(serviceBase + 'odata/Events', newEvent).then(function(results){
        return results;
      });
    };
    eventsServiceFactory.getEvents = _getEvents;
    eventsServiceFactory.newEvent = _newEvent;
    eventsServiceFactory.getEvent = _getEvent;
    return eventsServiceFactory;

}]);