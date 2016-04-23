﻿(function () {
    'use strict';

    angular
        .module('app.drivers')
        .controller('DriversController', Drivers);

    Drivers.$inject = ['driversApi', 'common', '$scope'];

    function Drivers(driversApi, common, $scope) {
        var vm = this;
        vm.title = 'cars';
        vm.editDriver = {};
        vm.tempDriver = {};
        vm.tempIndex = 0;
        vm.drivers = [];
        vm.isNew = true;
        vm.title = "";

        vm.getDrivers = function () {
            driversApi.getDrivers()
                .then(function (data) {
                    vm.drivers = data;
                });
        };

        vm.addDriver = function () {
            vm.title = "add driver";
            vm.isNew = true;
            vm.tempDriver = {};
            vm.tempIndex = 0;
        };

        //vm in ng-repeat not working! (we use scope)
        $scope.editDriver = function (driver, index) {
            vm.title = "edit driver";
            vm.isNew = false;
            vm.tempIndex = index;
            vm.editDriver = driver;
            driversApi.getDriver(driver.id)
                .then(function (data) {
                    vm.tempDriver = data;
                });
        };

        vm.saveDriver = function () {
            if (vm.isNew) {
                driversApi.addDriver(vm.tempDriver)
                .then(function () {
                    vm.drivers.push(vm.tempDriver);
                    CloseModal();
                });
            }
            else {
                driversApi.updateDriver(vm.tempDriver)
                .then(function () {
                    vm.editDriver = vm.tempDriver;
                    CloseModal();
                });
            }
        };

        vm.deleteDriver = function () {
            driversApi.deleteDriver(vm.tempDriver.id)
                .then(function () {
                    vm.drivers.splice(vm.tempIndex, 1);
                    common.getCars();
                    CloseModal();
                });
        };

        function CloseModal() {
            angular.element('#DriverModal').modal('hide');
        };
    }
})();
