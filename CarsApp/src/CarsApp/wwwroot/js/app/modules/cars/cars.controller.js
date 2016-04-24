(function () {
    'use strict';

    //controller for cars part front-end
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
        
        //get cars, also enable this reference in common module
        common.getCars = vm.getCars = function () {
            carsApi.getCars()
                .then(function (data) {
                    vm.cars = data;
                });
        };

        //after click add button
        vm.addCar = function () {
            vm.title = "add car";
            vm.isNew = true;
            vm.tempCar = {};
            vm.tempIndex = 0;
            vm.getDrivers();
        };

        //after click edit button
        //vm in ng-repeat not working! (we use scope)
        $scope.editCar = function (car, index) {
            vm.title = "edit car";
            vm.isNew = false;
            vm.tempIndex = index;
            common.copyProperties(car, vm.tempCar);
            vm.getDrivers();
        };

        //add or update item
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

        //delete item
        vm.deleteCar = function () {
            carsApi.deleteCar(vm.tempCar.id)
                .then(function () {
                    vm.cars.splice(vm.tempIndex, 1);
                    CloseModal();
                });
        };

        //close modal window
        function CloseModal() {
            angular.element('#CarModal').modal('hide');
        };

        //get all drivers via drivers api factory
        vm.getDrivers = function () {
            driversApi.getDrivers()
                .then(function (data) {
                    vm.drivers = data;
                });
        };
    }
})();
