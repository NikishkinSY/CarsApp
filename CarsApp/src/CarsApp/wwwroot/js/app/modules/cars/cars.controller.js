(function () {
    'use strict';

    angular
        .module('app.cars')
        .controller('CarsController', Cars);

    Cars.$inject = ['carsApi', 'driversApi', 'common', '$scope'];

    function Cars(carsApi, driversApi, common, $scope) {
        var vm = this;
        vm.title = 'cars';
        vm.tempCar = {};
        vm.tempIndex = 0;
        vm.cars = [];
        vm.isNew = true;
        vm.title = "";
        vm.drivers = [];
        
        common.getCars = vm.getCars = function () {
            carsApi.getCars()
                .then(function (result) {
                    vm.cars = result;
                });
        };

        function getCar(id) {
            carsApi.getCar(id)
                .then(function (result) {
                    return result;
                });
        };

        vm.addCar = function () {
            vm.title = "add car";
            vm.isNew = true;
            vm.tempCar = {};
            vm.tempIndex = 0;
            vm.getDrivers();
        };

        //vm in ng-repeat not working! (we use scope)
        $scope.editCar = function (car, index) {
            vm.title = "edit car";
            vm.isNew = false;
            vm.tempIndex = index;
            vm.tempCar = car;
            vm.getDrivers();
        };

        vm.saveCar = function () {
            if (vm.isNew)
            {
                carsApi.addCar(vm.tempCar)
                .then(function (result) {
                    vm.tempCar.driver = result.data.driver;
                    vm.cars.push(vm.tempCar);
                    CloseModal();
                });
            }
            else
            {
                carsApi.updateCar(vm.tempCar)
                .then(function (result) {
                    vm.tempCar.driver = result.data.driver;
                    CloseModal();
                });
            }
        };

        vm.deleteCar = function () {
            carsApi.deleteCar(vm.tempCar.id)
                .then(function () {
                    vm.cars.splice(vm.tempIndex, 1);
                    CloseModal();
                });
        };

        function CloseModal() {
            angular.element('#CarModal').modal('hide');
        };

        vm.getDrivers = function () {
            driversApi.getDrivers()
                .then(function (result) {
                    vm.drivers = result;
                });
        };
    }
})();
