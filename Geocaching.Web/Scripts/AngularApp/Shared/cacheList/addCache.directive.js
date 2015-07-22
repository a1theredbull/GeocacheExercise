(function () {
    "use strict";

    angular.module("GeocachingApp")
        .directive("addCache", ['GeocachingDataService', function (GeocachingDataService) {
            return {
                restrict: "E",
                templateUrl: "/Scripts/AngularApp/Shared/cacheList/addCache.directive.html",
                controller: function ($scope) {
                    /* start add process */
                    $scope.openAddCacheModal = function () {
                        $('#add-cache-modal').modal('show');
                    }

                    /* validation */
                    $scope.alphaNumericSpaces = /^[\w ]{6,50}$/;

                    /* confirm add */
                    $scope.addCache = function (name, longitude, latitude) {
                        var cache = {
                            Name:       name,
                            Longitude:  longitude,
                            Latitude:   latitude
                        }

                        // reset form fields
                        $scope.name =        "";
                        $scope.longitude =   "";
                        $scope.latitude =    "";

                        GeocachingDataService.addCache(cache).success(function() {
                            $('#add-cache-modal').modal('hide');
                        });
                    };

                    /* check form for validation errors */
                    $scope.anyErrorsOnForm = function () {
                        $scope.formError = "";

                        if ($scope.addCacheForm.name.$error.pattern || 
                            $scope.addCacheForm.name.$error.required) {
                            $scope.formError = "Name must be alphanumeric and between 6-50 characters.";
                        } else if ($scope.addCacheForm.longitude.$error.required) {
                            $scope.formError = "Longitude is required or is not in a correct format.";
                        } else if ($scope.addCacheForm.latitude.$error.required) {
                            $scope.formError = "Latitude is required or is not in a correct format.";
                        }
                    }
                }
            }
        }]);
})();