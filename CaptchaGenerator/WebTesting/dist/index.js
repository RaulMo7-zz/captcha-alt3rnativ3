(function () {

// Declare app level module which depends on views, and components
    var module = angular.module('ngCaptcha', []);
    module.directive('angularCaptcha', function () {
        var controller = ['$scope', function ($scope) {
                $scope.addItem = function () {
                    $scope.add();
                };
            }],

            template = '<button ng-click="addItem()">Add Item</button>'

        return {
            restrict: 'EA',
            scope: {
                add: '&',
            },
            controller: controller,
            template: template
        };
    });

}())