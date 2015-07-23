(function () {
    "use strict";

    angular.module("GeocachingApp")
        .directive("cacheList", ['GeocachingDataService', function (GeocachingDataService) {
            return {
                restrict: "E",
                templateUrl: "/Scripts/AngularApp/Shared/cacheList/cacheList.directive.html",
                link: function (scope, element, attrs) {
                    /* Initialization */
                    scope.loading = true;
                    GeocachingDataService.getCaches().success(function () {
                        scope.loading = false;
                    });

                    scope.geocaching = GeocachingDataService;

                    scope.InitializeMarker = function () {
                        scope.map = {
                            center: {
                                latitude: 42.96,
                                longitude: -85.65,
                            },
                            marker: {
                                latitude: 42.96,
                                longitude: -85.65
                            },
                            zoom: 12,
                            markerID: -1
                        };
                    }

                    scope.$watch('geocaching.selectedCache', function () {
                        //check if not empty object
                        if (Object.keys(scope.geocaching.selectedCache).length > 0) {
                            scope.map = {
                                center: {
                                    latitude: scope.geocaching.selectedCache.Latitude,
                                    longitude: scope.geocaching.selectedCache.Longitude
                                },
                                marker: {
                                    latitude: scope.geocaching.selectedCache.Latitude,
                                    longitude: scope.geocaching.selectedCache.Longitude
                                },
                                zoom: 12,
                                markerID: scope.geocaching.selectedCache.ID
                            };
                        }
                    });

                    scope.deleteCache = function (id) {
                        GeocachingDataService.deleteCache(id);
                    }
                }
            }
        }]);
})();