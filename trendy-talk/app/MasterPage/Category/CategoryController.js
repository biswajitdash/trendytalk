templatingApp.controller('CategoryController', ['$scope', '$http', function ($scope, $http) {
    $scope.title = "CategoryController";
    $scope.ListCategory = null;
    $scope.categoryModel = {};
    $scope.categoryModel.categoryId = 0;
    getallData();

    //******=========Get All Category=========******
    function getallData() {
        $http({
            method: 'GET',
            url: '/api/Category/GetCategory/'
        }).then(function (response) {
            $scope.ListCategory = response.data;
        }, function (error) {
            console.log(error);
        });
    };

    //******=========Get Single Category=========******
    $scope.getCategory = function (category) {
        $http({
            method: 'GET',
            url: '/api/Category/GetCategoryByID/' + parseInt(category.categoryId)
        }).then(function (response) {
            $scope.categoryModel = response.data;
        }, function (error) {
            console.log(error);
        });
    };

    //******=========Save Category=========******
    $scope.saveCategory = function () {
        $http({
            method: 'POST',
            url: '/api/Category/PostCategory/',
            data: $scope.categoryModel
        }).then(function (response) {
            $scope.reset();
            getallData();
        }, function (error) {
            console.log(error);
        });
    };

    //******=========Update Category=========******
    $scope.updateCategory = function () {
        $http({
            method: 'PUT',
            url: '/api/Category/PutCategory/' + parseInt($scope.categoryModel.categoryId),
            data: $scope.categoryModel
        }).then(function (response) {
            $scope.reset();
            getallData();
        }, function (error) {
            console.log(error);
        });
    };

    //******=========Delete Category=========******
    $scope.deleteCategory = function (category) {
        var IsConf = confirm('You are about to delete ' + category.categoryName + '. Are you sure?');
        if (IsConf) {
            $http({
                method: 'DELETE',
                url: '/api/Category/DeleteCategoryByID/' + parseInt(category.categoryId)
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
        $scope.categoryModel = {};
        $scope.categoryModel.categoryId = 0;
    };
}]);