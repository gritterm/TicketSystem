'use strict';
app.controller('customerController', ['$routeParams', '$scope', 'customersService', function ($routeParams, $scope, customersService) {
   var customerid = $routeParams.customerId;
   customersService.getCustomer(customerid).then(function(results){
        $scope.customer = results.data;
   });   
}]);