(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdminPanelService', AdminPanelService);

    AdminPanelService.$inject = ['$http'];
    function AdminPanelService($http) {
        var service = {};
        var apiPrefix = 'http://localhost:53160';
        //service.GetCountry = GetCountry;
        //service.GetById = GetById;
        //service.GetByUsername = GetByUsername;
        service.Create = Create;
        //service.Update = Update;
        //service.Delete = Delete;

        return service;

        function Create(adminpanel) {
            return $http.post(apiPrefix + '/api/AdminPanel/saveadminpanel', adminpanel).then(handleSuccess, handleError('Error creating NewsChannel'));
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
