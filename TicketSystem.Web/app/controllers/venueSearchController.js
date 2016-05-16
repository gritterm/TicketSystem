'use strict';
app.controller('venueSearchController', ['$scope', '$route', 'venuesService', function ($scope, $route,venuesService) {

    $scope.venues = [];
    $scope.searchoptions = {};
    $scope.searchoptions.newEntityName = "New Venue";
    $scope.searchoptions.columnDefs = [{
        name: 'Venue_Name',
        cellTemplate:'<div>' +
                   '<a href="http://localhost:32150/#/Venue/{{row.entity.Venue_ID}}">{{row.entity.Venue_Name}}</a>' +
                   '</div>'
    }
    ];
    
    $scope.newVenue = {
    };

    $scope.saveVenue = saveVenue;

    $scope.searchoptions.newEntityAction = function(){
        $('#myModal').modal('show')
    };  
    venuesService.getVenues().then(function (results) {
        $scope.searchoptions.data = results.data.value;
        $scope.searchoptions.enableFiltering = true;     
    }, function (error) {
        //alert(error.data.message);
    });

    function saveVenue()
    {
        venuesService.newVenue($scope.newVenue).then(function(results) {
            $('#myModal').modal('hide')
            var venue = results.data;
            window.location = 'http://localhost:32150/#/Venue/' + venue.Venue_ID
        });
    }

}]);