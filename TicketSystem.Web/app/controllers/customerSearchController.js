'use strict';
app.controller('customerSearchController', ['$scope', 'customersService', function ($scope, customersService) {

    $scope.customers = [];
    $scope.searchoptions = {};
    $scope.searchoptions.newEntityName = "New Customer";
    $scope.searchoptions.columnDefs = [{
        name: 'Customer_Name',
        cellTemplate:'<div>' +
                   '<a href="http://localhost:32150/#/Customer/{{row.entity.Customer_ID}}">{{row.entity.Customer_Name}}</a>' +
                   '</div>'
    },
    {
        name: 'Customer_Email'
    }];
    $scope.cardColumnLink = "Customer_ID";
    $scope.cardLinkTemplate = '<div>' +
                   '<a href="http://stackoverflow.com">Click me</a>' +
                   '</div>'
    $scope.newCustomer = {
    };

    $scope.saveCustomer = saveCustomer;

    $scope.searchoptions.newEntityAction = function(){
        $('#myModal').modal('show')
    };  
    customersService.getCustomers().then(function (results) {
        $scope.searchoptions.data = results.data.value;
        $scope.searchoptions.enableFiltering = true;     
    }, function (error) {
        //alert(error.data.message);
    });

    function saveCustomer()
    {
        customersService.newCustomer($scope.newCustomer);
    }

}]);