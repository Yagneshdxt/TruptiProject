var StudentApp = angular.module('StudentApp');
StudentApp.controller('loginController', ['$location', function ($location) {
    
    this.EmailId = "asdfas";
    this.EnrollmentNo = "";
    this.Password = "";
    
    this.signIn = function(){
        //check client side validity.
        //call http service to authenticate.
        //if autheticated sucessfully  
           //1. store user details in some common location.
           //2. Redirect to  
        //if unauthorize prompt for error message.

        $location.path('RegisterUser');
    }

    this.IsEmailOrEnrollmentPresent = function(){
       return !(this.EmailId || this.EnrollmentNo);
    }
}]);

