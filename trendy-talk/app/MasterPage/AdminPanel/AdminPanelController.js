templatingApp.controller('AdminPanelController', ['$scope', '$http', function ($scope, $http) {
    $scope.title = "AdminPanelController";
    $scope.ListCategory = null;
    $scope.ListCountry = null;
    $scope.categoryModel = {};
    $scope.categoryModel.categoryId = 0;
    $scope.countryModel = {};
    $scope.countryModel.countryId = 0;
    $scope.newsChannels = [];
    $scope.Name = null;
    $scope.adminPanel = {};

    GetCategory();
    GetCountry();

    function GetCategory() {
        $http({
            method: 'GET',
            url: '/api/Category/GetCategory/'
        }).then(function (response) {
            $scope.ListCategory = response.data;
        }, function (error) {
            console.log(error);
        });
    };

    function GetCountry() {
        $http({
            method: 'GET',
            url: '/api/Country/GetCountry/'
        }).then(function (response) {
            $scope.ListCountry = response.data;
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

    $scope.createNewsChannels = function () {
        $http({
            method: 'DELETE',
            url: '/api/Country/DeleteCountryByID/' + parseInt(country.countryId)
        }).then(function (response) {
            $scope.reset();
            getallData();
        }, function (error) {
            console.log(error);
        });
    };

    ////******=========Get Single Category=========******
    //$scope.getCategory = function (category) {
    //    $http({
    //        method: 'GET',
    //        url: '/api/Category/GetCategoryByID/' + parseInt(category.categoryId)
    //    }).then(function (response) {
    //        $scope.categoryModel = response.data;
    //    }, function (error) {
    //        console.log(error);
    //    });
    //};

    ////******=========Save Category=========******
    //$scope.saveCategory = function () {
    //    $http({
    //        method: 'POST',
    //        url: '/api/Category/PostCategory/',
    //        data: $scope.categoryModel
    //    }).then(function (response) {
    //        $scope.reset();
    //        getallData();
    //    }, function (error) {
    //        console.log(error);
    //    });
    //};

    ////******=========Update Category=========******
    //$scope.updateCategory = function () {
    //    $http({
    //        method: 'PUT',
    //        url: '/api/Category/PutCategory/' + parseInt($scope.categoryModel.categoryId),
    //        data: $scope.categoryModel
    //    }).then(function (response) {
    //        $scope.reset();
    //        getallData();
    //    }, function (error) {
    //        console.log(error);
    //    });
    //};

    ////******=========Delete Category=========******
    //$scope.deleteCategory = function (category) {
    //    var IsConf = confirm('You are about to delete ' + category.categoryName + '. Are you sure?');
    //    if (IsConf) {
    //        $http({
    //            method: 'DELETE',
    //            url: '/api/Category/DeleteCategoryByID/' + parseInt(category.categoryId)
    //        }).then(function (response) {
    //            $scope.reset();
    //            getallData();
    //        }, function (error) {
    //            console.log(error);
    //        });
    //    }
    //};

    ////******=========Clear Form=========******
    //$scope.reset = function () {
    //    var msg = "Form Cleared";
    //    $scope.categoryModel = {};
    //    $scope.categoryModel.categoryId = 0;
    //};
}]);