(function () {
    'use strict';

    angular
        .module('app')
        .factory('CategoryService', CategoryService);

    CategoryService.$inject = ['$http'];
    function CategoryService($http) {
        var service = {};
        var apiPrefix = 'http://localhost:53160';
        service.GetCategory = GetCategory;
        service.GetById = GetById;
        //service.GetByUsername = GetByUsername;
        service.Create = Create;
        service.Update = Update;
        service.Delete = Delete;

        return service;

        function GetCategory() {
            return $http.get(apiPrefix + '/api/Category/GetCategory').then(handleSuccess, handleError('Error getting all category'));
        }

        function GetById(id) {
            return $http.get(apiPrefix + '/Users/id?id=' + id).then(handleSuccess, handleError('Error getting user by id'));
        }

        function Create(user) {
            return $http.post(apiPrefix + '/Users/register', user).then(handleSuccess, handleError('Error creating user'));
        }

        function Update(user) {
            return $http.put(apiPrefix + '/Users/' + user.id, user).then(handleSuccess, handleError('Error updating user'));
        }

        function Delete(id) {
            return $http.delete(apiPrefix + '/Users/' + id).then(handleSuccess, handleError('Error deleting user'));
        }

        // private functions

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();
