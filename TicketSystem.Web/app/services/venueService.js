'use strict';
app.factory('venueService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var venuevenuevesServiceFactory = {};

    var _getVenues = function () {

        return $http.get(serviceBase + 'odata/Venues').then(function (results) {
            return results;
        });
    };
    var _getVenue = function (venueId) {
        return $http.get(serviceBase + 'odata/Venues/?key=' + venueId).then(function(results){
            return results;
        });
    };
    var _newVenue = function(newVenue)
    {
      return $http.post(serviceBase + 'odata/Venues', newVenue).then(function(results){
        return results;
      });
    }
    venuesServiceFactory.getVenues = _getVenues;
    venuesServiceFactory.newVenue = _newVenue;
    venuesServiceFactory.getVenue = _getVenue;
    return venuesServiceFactory;

}]);