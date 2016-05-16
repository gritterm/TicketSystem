
var app = angular.module('AngularAuthApp', ['ngRoute',  'ui.select', 'LocalStorageModule', 'angular-loading-bar', 'ui.grid']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

     $routeProvider.when("/customerSearch", {
        controller: "customerSearchController",
        templateUrl: "/app/views/customerSearch.html"
    });

    $routeProvider.when("/ticketPurchases", {
        controller: "ticketPurchaseSearchController",
        templateUrl: "/app/views/ticketPurchaseSearch.html"
    });

    $routeProvider.when("/Customer/:customerId" , {
        controller: "customerController",
        templateUrl: "/app/views/customerCard.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/venues", {
        controller: "venueSearchController",
        templateUrl: "/app/views/venueSearch.html"
    });

    $routeProvider.when("/eventTypes", {
        controller: "eventTypeSearchController",
        templateUrl: "/app/views/eventTypeSearch.html"
    });

    $routeProvider.when("/events", {
        controller: "eventSearchController",
        templateUrl: "/app/views/eventSearch.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

//var serviceBase = 'http://localhost:26264/';
var serviceBase = 'http://localhost:26264/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


