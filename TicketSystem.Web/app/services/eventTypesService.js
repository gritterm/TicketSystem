'use strict';
app.factory('eventTypesService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var eventTypesServiceFactory = {};

    var _getEventTypes = function () {

        return $http.get(serviceBase + 'odata/EventTypes').then(function (results) {
            return results;
        });
    };
    var _getEventType = function (eventTypeId) {
        return $http.get(serviceBase + 'odata/EventTypes/?key=' + eventTypeId).then(function(results){
            return results;
        });
    };
    var _newEventType = function(newEventType)
    {
      return $http.post(serviceBase + 'odata/EventTypes', newEventType).then(function(results){
        return results;
      });
    }
    eventTypesServiceFactory.getEventTypes = _getEventTypes;
    eventTypesServiceFactory.newEventType = _newEventType;
    eventTypesServiceFactory.getEventType = _getEventType;
    return eventTypesServiceFactory;

}]);