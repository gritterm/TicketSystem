'use strict';
app.controller('customerSearchController', ['$scope', 'customersService', function ($scope, customersService) {

    $scope.customers = [];
    $scope.searchoptions = {};
    $scope.searchoptions.newEntityName = "New Customer";
    $scope.newCustomer = {
    };

    $scope.saveCustomer = saveCustomer;

    $scope.searchoptions.newEntityAction = function(){
        $('#myModal').modal('show')
    };  
    customersService.getCustomers().then(function (results) {
        $scope.searchoptions.gridData = results.data.value;

    }, function (error) {
        //alert(error.data.message);
    });

    function saveCustomer()
    {
        customersService.newCustomer($scope.newCustomer);
    }

}]);