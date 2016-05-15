'use strict';
app.factory('customersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var customersServiceFactory = {};

    var _getCustomers = function () {

        return $http.get(serviceBase + 'odata/Customers').then(function (results) {
            return results;
        });
    };
    var _newCustomer = function(newCustomer)
    {
      return $http.post(serviceBase + 'odata/Customers', newCustomer).then(function(results){
        return results;
      });
    }
    customersServiceFactory.getCustomers = _getCustomers;
    customersServiceFactory.newCustomer = _newCustomer;
    return customersServiceFactory;

}]);