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
                .then(function (data) {
                    vm.cars = data;
                });
        };

        function getCar(id) {
            carsApi.getCar(id)
                .then(function (data) {
                    return data;
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
            common.copyProperties(car, vm.tempCar);
            vm.getDrivers();
        };

        vm.saveCar = function () {
            if (vm.isNew)
            {
                carsApi.addCar(vm.tempCar)
                .then(function (data) {
                    vm.cars.push(data);
                    CloseModal();
                });
            }
            else
            {
                carsApi.updateCar(vm.tempCar)
                .then(function (data) {
                    common.copyProperties(data, vm.cars[vm.tempIndex]);
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
                .then(function (data) {
                    vm.drivers = data;
                });
        };
    }
})();
