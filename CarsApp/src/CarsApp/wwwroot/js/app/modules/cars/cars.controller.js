(function () {
    'use strict';

    angular
        .module('app.cars')
        .controller('CarsController', Cars);

    Cars.$inject = ['carsApi'];

    function Cars(carsApi) {
        var vm = this;
        vm.title = 'cars';
        vm.tempCar = {};
        vm.tempIndex = 0;
        vm.cars = [];
        vm.isNew = true;
        vm.title = "";

        vm.getCars = function () {
            carsApi.getCars()
                .then(function (data) {
                    vm.cars = data;
                });
        };

        vm.addCar = function () {
            vm.title = "add car";
            vm.isNew = true;
        };

        vm.editCar = function (car, index) {
            vm.title = "edit car";
            vm.isNew = false;
            vm.tempCar = car;
            vm.tempIndex = index;
        };

        vm.saveCar = function () {
            if (vm.isNew)
            {
                carsApi.addCar(vm.tempCar)
                .then(function () {
                    vm.cars.push(vm.tempCar);
                    refreshTemp();
                    closeModal();
                });
            }
            else
            {
                carsApi.updateCar(vm.tempCar)
                .then(function () {
                    refreshTemp();
                    closeModal();
                });
            }
        };

        vm.deleteCar = function (id, index) {
            carsApi.deleteCar(id)
                .then(function () {
                    vm.cars.splice(index, 1);
                });
        };

        function closeModal() {
            angular.element('#CarModal').modal('hide');
        };

        function refreshTemp() {
            vm.tempCar = {};
            vm.tempIndex = 0;
            vm.title = "";
        };
    }
})();
