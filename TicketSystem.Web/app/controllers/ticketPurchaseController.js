'use strict';
app.controller('ticketPurchaseController', 
    ['$routeParams','$scope', 'ticketPurchasesService', 'customersService', 'eventsService',
 function ($routeParams, $scope, ticketPurchasesService, customersService, eventsService) {
    var ticketId = $routeParams.ticketId;

    $scope.saveTicketPurchase = saveTicketPurchase;

  
    ticketPurchasesService.getTicketWithLines(ticketId).then(function (results) {
        $scope.ticketPurchase = results.data;
        
    }, function (error) {
        //alert(error.data.message);
    });

     customersService.getCustomers().then(function (results){
        $scope.customers = results.data.value;
        $scope.selectedCustomer = { value: $scope.customers[0] };
    });

     function saveTicketPurchase ()
     {
        ticketPurchasesService.editTicket($scope.newVenue).then(function(results) {
            $('#myModal').modal('hide')
            var venue = results.data;
            window.location = 'http://localhost:32150/#/Venue/' + venue.Venue_ID
        });
     }

}]);