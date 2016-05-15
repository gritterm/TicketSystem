'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.orders = [];
    $scope.searchoptions = {};
    $scope.searchoptions.newEntityName = "New Order";
    $scope.searchoptions.newEntityAction = function(){

    };
    ordersService.getOrders().then(function (results) {

        $scope.searchoptions.gridData = results.data;

    }, function (error) {
        alert(error.data.message);
    });

}]);