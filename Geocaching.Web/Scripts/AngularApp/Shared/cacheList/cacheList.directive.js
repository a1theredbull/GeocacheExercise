(function () {
    "use strict";

    angular.module("GeocachingApp")
        .directive("cacheList", ['GeocachingDataService', function (GeocachingDataService) {
            return {
                restrict: "E",
                templateUrl: "/Scripts/AngularApp/Shared/cacheList/cacheList.directive.html",
                link: function (scope, element, attrs) {
                    /* initialize */
                    scope.loading = true;
                    GeocachingDataService.getCaches().success(function () {
                        scope.loading = false;
                    });

                    scope.geocaching = GeocachingDataService;

                    scope.deleteCache = function (id) {
                        GeocachingDataService.deleteCache(id);
                    }
                }
            }
        }]);
})();