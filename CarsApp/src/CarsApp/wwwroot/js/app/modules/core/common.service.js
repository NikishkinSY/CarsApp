(function () {
    'use strict';

    angular
        .module('app.core')
        .service('common', Common);

    Common.$inject = [];

    function Common() {
        var getCars;
        var service = {
            getCars: getCars
        };

        return service;

    }
})();