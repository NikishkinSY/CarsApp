(function () {
    'use strict';

    angular
        .module('app.core')
        .service('common', Common);

    Common.$inject = [];

    function Common() {
        var service = {
            getCars: getCars,
            copyProperties: copyProperties
        };

        return service;

        //function refresh list of cars
        var getCars;

        //copy properties (map)
        function copyProperties (src, dst) {
            for (var propety in src)
                dst[propety] = src[propety];
        };
    }
})();