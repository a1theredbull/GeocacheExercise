(function () {
    "use strict";

    angular.module("GeocachingApp")
        .directive("cacheList", ['GeocachingDataService', function (GeocachingDataService) {
            return {
                restrict: "E",
                templateUrl: "/Scripts/AngularApp/Shared/cacheList/cacheList.directive.html",
                controller: function ($scope) {
                    console.log("Service");
                    console.log(GeocachingDataService.getCaches());
                }
            }
        }]);
})();