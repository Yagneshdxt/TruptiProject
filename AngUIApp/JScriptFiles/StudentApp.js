// app.js
var StudentApp = angular.module('StudentApp', ['ui.router']);
StudentApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');
    $stateProvider
        // HOME STATES AND NESTED VIEWS ========================================
        .state('home', {
            url: '/home',
            templateUrl: 'login.html',
            controller: "loginController",
            controllerAs: "lc"
        })
        .state('forgotPassword', {
            url: '/forgotPassword',
            templateUrl: 'forgotPassword.html',
            controller: "forgotPasswordController",
            controllerAs: "FP"
        })
        .state('RegisterUser', {
            url: '/RegisterUser',
            templateUrl: 'forgotPassword.html',
            controller: "forgotPasswordController",
            controllerAs: "FP"
        })
});
