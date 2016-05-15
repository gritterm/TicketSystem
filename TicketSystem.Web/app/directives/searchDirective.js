//var app = angular.module('AngularAuthApp', []);

app.directive('searchDirective', function() {
  return {
      restrict: 'AE',
      scope:{
        searchOptions : '='
      },
      template: '<button ng-click="searchOptions.newEntityAction()">{{searchOptions.newEntityName}}</button><div ui-grid="{data: searchOptions.gridData ,enableFiltering:true}" class="myGrid"></div>',
      link: function(scope, elem, attrs) {
        
      }

  };
});