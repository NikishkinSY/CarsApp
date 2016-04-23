(function () {
    'use strict';

    angular
        .module('app.drivers')
        .factory('driversApi', driversApi);

    driversApi.$inject = ['$http'];

    function driversApi($http) {
        var service = {
            getDrivers: getDrivers,
            getDriver: getDriver,
            addDriver: addDriver,
            updateDriver: updateDriver,
            deleteDriver: deleteDriver
        };

        return service;

        function getDrivers() {
            return $http({
                url: "/api/Drivers",
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function getDriver(id) {
            return $http({
                url: "/api/Drivers/" + id,
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function addDriver(driver) {
            return $http({
                url: "/api/Drivers",
                method: "PUT",
                data: driver
            })
            .then(function (response) {
                return response;
            })
            .catch(console.log.bind(console));
        };

        function updateDriver(driver) {
            return $http({
                url: "/api/Drivers",
                method: "POST",
                data: driver
            })
            .then(function (response) {
                return response;
            })
            .catch(console.log.bind(console));
        };

        function deleteDriver(id) {
            return $http({
                url: "/api/Drivers/" + id,
                method: "DELETE"
            })
            .then(function (response) {
                return response;
            })
            .catch(console.log.bind(console));
        };
    }
})();