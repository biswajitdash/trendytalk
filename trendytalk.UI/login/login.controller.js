(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', 'AuthenticationService', 'FlashService'];
    function LoginController($location, AuthenticationService, FlashService) {
        var vm = this;

        vm.login = login;

        vm.goToPage = function (page) {
            if (page != "" && page != "#") {
                $location.path(page);
            }

        };

        vm.logout = function () {
            vm.SiteMenu = [];
            userProfile.logout();
            $location.path('/');
        };

        (function initController() {
            // reset login status
            AuthenticationService.ClearCredentials();
        })();

        function login() {
            vm.dataLoading = true;
            AuthenticationService.Login(vm.username, vm.password, function (response) {
                //if (response.success) {

                if (response !== null && response.status == 200) {
                    AuthenticationService.SetCredentials(response.data, vm.password);
                    vm.isSignedIn = true;
                    $location.path('/home');
                } else {
                    FlashService.Error(response.message);
                    vm.dataLoading = false;
                }
            });
        };
    }

})();
