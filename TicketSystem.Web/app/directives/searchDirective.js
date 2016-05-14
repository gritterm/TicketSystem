//var app = angular.module('AngularAuthApp', []);

app.directive('searchDirective', function() {
  return {
      restrict: 'AE',
      scope:{
        gridoptions : '='
      },
      template: '<div ui-grid="{data: gridoptions}" class="myGrid"></div>',
      link: function(scope, elem, attrs) {
        
      }

  };
});