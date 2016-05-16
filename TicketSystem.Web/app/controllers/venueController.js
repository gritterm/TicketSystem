'use strict';
app.controller('venueController', ['$routeParams', '$scope', 'venuesService', function ($routeParams, $scope, venuesService) {
   var venueid = $routeParams.venueId;
   venuesService.getvenue(venueid).then(function(results){
        $scope.venue = results.data;
   });   
}]);