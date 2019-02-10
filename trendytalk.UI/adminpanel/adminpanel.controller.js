(function () {
    'use strict';

    angular
        .module('app')
        .controller('AdminPanelController', AdminPanelController);

    AdminPanelController.$inject = ['CategoryService', 'CountryService', 'AdminPanelService', '$scope', 'FlashService'];
    function AdminPanelController(CategoryService, CountryService, AdminPanelService, $scope, FlashService) {

        $scope.title = "AdminPanelController";
        $scope.ListCategory = [];
        $scope.ListCountry = [];
        $scope.selectedCategory = null;
        $scope.selectedCountry = null;
        //$scope.categoryModel = {};
        //$scope.categoryModel.categoryId = 0;
        //$scope.countryModel = {};
        //$scope.countryModel.countryId = 0;
        $scope.newsChannels = [];
        $scope.Name = null;
        $scope.adminPanel = {};

        initController();

        function initController() {
            GetCategory();
            GetCountry();
        }

        function GetCategory() {
            CategoryService.GetCategory().then(function (response) {
                $scope.ListCategory = response;
            }, function (error) {
                console.log(error);
            });
        };

        function GetCountry() {
            CountryService.GetCountry().then(function (response) {
                $scope.ListCountry = response;
            }, function (error) {
                console.log(error);
            });
        };

        $scope.Add = function () {
            //Add the new item to the Array.
            var newsChannel = {};
            newsChannel.Name = $scope.Name;
            $scope.newsChannels.push(newsChannel);
            //Clear the TextBoxes.
            $scope.Name = "";
        };

        $scope.Remove = function (index) {
            //Find the record using Index from Array.
            var name = $scope.newsChannels[index].Name;
            if (confirm("Do you want to delete: " + name)) {
                //Remove the item from Array using Index.
                $scope.newsChannels.splice(index, 1);
            }
        }
    }

})();
