'use strict';

angular.module('myApp.view1', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/view1', {
            templateUrl: 'view1/view1.html',
            controller: 'View1Ctrl'
        });
    }])

    .controller('View1Ctrl', ['$scope', '$http', function ($scope, $http) {

        $scope.selectedAnswer = 0;

        $scope.generateNewCaptcha = function () {
            $http({
                method: 'GET',
                url: 'http://localhost:58374/api/captcha/generate'
            }).then(function successCallback(response) {
                $scope.data = response.data;
            }, function errorCallback(response) {
            });
        };

        $scope.validateCaptcha = function () {
            $http({
                method: 'GET',
                url: 'http://localhost:58374/api/captcha/validate'
            }).then(function successCallback(response) {
                alert("validation result: " + response.data);
            }, function errorCallback(response) {
            });
        }

        $scope.generateNewCaptcha();


    }]);