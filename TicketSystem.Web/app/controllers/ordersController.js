'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.orders = [];
    $scope.gridoptions = [];
    ordersService.getOrders().then(function (results) {

        $scope.gridoptions = results.data;

    }, function (error) {
        alert(error.data.message);
    });

}]);