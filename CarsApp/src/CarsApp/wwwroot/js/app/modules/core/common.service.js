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

        var getCars;

        //copy properties (map)
        function copyProperties (src, dst) {
            for (var propety in src)
                dst[propety] = src[propety];
        };
    }
})();