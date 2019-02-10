(function () {
    'use strict';

    angular
        .module('app')
        .controller('CountryController', CountryController);

    CountryController.$inject = ['CountryService', '$scope', 'FlashService'];
    function CountryController(CountryService, $scope, FlashService) {

        $scope.title = "CountryController";
        $scope.ListCountry = [];
        $scope.countryModel = {};
        $scope.countryModel.countryId = 0;

        initController();

        function initController() {
            CountryService.GetCountry().then(function (response) {
                $scope.ListCountry = response;
            }, function (error) {
                console.log(error);
            });
        }

        //******=========Get All Country=========******
        function getallData() {
            $http({
                method: 'GET',
                url: '/api/Country/GetCountry/'
            }).then(function (response) {
                $scope.ListCountry = response.data;
            }, function (error) {
                console.log(error);
            });
        };

        //******=========Get Single Country=========******
        $scope.getCountry = function (country) {
            $http({
                method: 'GET',
                url: '/api/Country/GetCountryByID/' + parseInt(country.countryId)
            }).then(function (response) {
                $scope.countryModel = response.data;
            }, function (error) {
                console.log(error);
            });
        };

        //******=========Save Country=========******
        $scope.saveCountry = function () {
            $http({
                method: 'POST',
                url: '/api/Country/PostCountry/',
                data: $scope.countryModel
            }).then(function (response) {
                $scope.reset();
                getallData();
            }, function (error) {
                console.log(error);
            });
        };

        //******=========Update Country=========******
        $scope.updateCountry = function () {
            $http({
                method: 'PUT',
                url: '/api/Country/PutCountry/' + parseInt($scope.countryModel.countryId),
                data: $scope.countryModel
            }).then(function (response) {
                $scope.reset();
                getallData();
            }, function (error) {
                console.log(error);
            });
        };

        //******=========Delete Country=========******
        $scope.deleteCountry = function (country) {
            var IsConf = confirm('You are about to delete ' + country.countryName + '. Are you sure?');
            if (IsConf) {
                $http({
                    method: 'DELETE',
                    url: '/api/Country/DeleteCountryByID/' + parseInt(country.countryId)
                }).then(function (response) {
                    $scope.reset();
                    getallData();
                }, function (error) {
                    console.log(error);
                });
            }
        };

        //******=========Clear Form=========******
        $scope.reset = function () {
            var msg = "Form Cleared";
            $scope.countryModel = {};
            $scope.countryModel.countryId = 0;
        };
    }

})();
