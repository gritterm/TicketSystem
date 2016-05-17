'use strict';
app.controller('ticketPurchaseSearchController', ['$scope', 'ticketPurchasesService', function ($scope, ticketPurchasesService) {

    $scope.searchoptions = {};
    $scope.searchoptions.newEntityName = "New Ticket Purchase";

    $scope.saveTicketPurchase = saveTicketPurchase;

    $scope.searchoptions.newEntityAction = function(){
       saveTicketPurchase();
    };  
    ticketPurchasesService.getTickets().then(function (results) {
        $scope.searchoptions.gridData = results.data.value;

    }, function (error) {
        //alert(error.data.message);
    });

    function saveTicketPurchase()
    {
        ticketPurchasesService.newTicket().then(function(result)
            {
                var ticket = result.data;
                window.location = 'http://localhost:32150/#/TicketPurchase/' + ticket.Ticket_Purchase_ID

            });
    }

}]);