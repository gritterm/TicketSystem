'use strict';
app.factory('ticketPurchasesService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var ticketPurchasesServiceFactory = {};

    var _getTicketPurchases = function () {

        return $http.get(serviceBase + 'odata/TicketPurchases').then(function (results) {
            return results;
        });
    };
    var _newTicket = function()
    {
      return $http.post(serviceBase + 'odata/TicketPurchases', {}).then(function(results){
        return results;
      });
    }
    ticketPurchasesServiceFactory.getTickets = _getTicketPurchases;
    ticketPurchasesServiceFactory.newCustomer = _newTicket;
    return ticketPurchasesServiceFactory;

}]);