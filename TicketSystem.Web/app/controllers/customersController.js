'use strict';
app.controller('customersController', ['$scope', 'customersService', function ($scope, customersService) {

    $scope.customers = [];

    ordersService.getCustomers().then(function (results) {
        $scope.customers = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);