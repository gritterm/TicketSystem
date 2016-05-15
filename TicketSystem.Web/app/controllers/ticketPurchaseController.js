'use strict';
app.controller('ticketPurchaseController', ['$scope', 'ticketPurchasesService', function ($scope, ticketPurchasesService) {

    $scope.searchoptions = {};
    $scope.searchoptions.newEntityName = "New Ticket Purchase";

    $scope.saveTicketPurchase = saveTicketPurchase;

    $scope.searchoptions.newEntityAction = function(){
        $('#myModal').modal('show')
    };  
    ticketPurchasesService.getTickets().then(function (results) {
        $scope.searchoptions.gridData = results.data.value;

    }, function (error) {
        //alert(error.data.message);
    });

    function saveTicketPurchase()
    {
        ticketPurchasesService.newTicketPurchase();
    }

}]);