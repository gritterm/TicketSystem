'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.orders = [];
    $scope.gridoptions = {};
    $scope.gridoptions.newEntityName = "New Order";
    $scope.gridoptions.newEntityAction = function(){
      
    };
    ordersService.getOrders().then(function (results) {

        $scope.gridoptions.gridData = results.data;

    }, function (error) {
        alert(error.data.message);
    });

}]);