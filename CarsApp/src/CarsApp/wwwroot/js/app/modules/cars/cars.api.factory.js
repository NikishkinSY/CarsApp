(function () {
    'use strict';

    //factory for receiving cars-data from server

    angular
        .module('app.cars')
        .factory('carsApi', carsApi);

    carsApi.$inject = ['$http'];

    function carsApi($http) {
        var service = {
            getCars: getCars,
            getCar: getCar,
            addCar: addCar,
            updateCar: updateCar,
            deleteCar: deleteCar
        };

        return service;

        function getCars() {
            return $http({
                url: "/api/Cars",
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function getCar(id) {
            return $http({
                url: "/api/Cars/" + id,
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function addCar(car) {
            return $http({
                url: "/api/Cars",
                method: "PUT",
                data: car
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function updateCar(car) {
            return $http({
                url: "/api/Cars",
                method: "POST",
                data: car
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        function deleteCar(id) {
            return $http({
                url: "/api/Cars/" + id,
                method: "DELETE"
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };
    }
})();