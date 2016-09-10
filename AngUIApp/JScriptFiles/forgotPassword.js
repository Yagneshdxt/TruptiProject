var StudentApp = angular.module('StudentApp');
StudentApp.controller('forgotPasswordController', [function () {
    this.EmailId = "";
    this.EnrollmentNo = "";
    this.GetPassword = function(){
        //check client side validity.
        //call http service to getPassword.
        //if sucessfully  
           //1. display message to user "Password send to your registerd email Id"
           //2. Redirect to login page  
        //if unauthorize prompt for error message.
    }

    this.IsEmailOrEnrollmentPresent = function(){
       return !(this.EmailId || this.EnrollmentNo);
    }
}]);

