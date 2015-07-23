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
                    $scope.alphaNumericSpacesRegex = /^[\w ]{6,50}$/;
                    $scope.longitudeRegex = /\s*[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$/;
                    $scope.latitudeRegex = /^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)$/;

                    /* confirm add */
                    $scope.addCache = function (name, longitude, latitude) {
                        if ($scope.anyErrorsOnForm()) {
                            return;
                        }

                        var cache = {
                            Name:       name,
                            Longitude:  longitude,
                            Latitude:   latitude
                        }

                        GeocachingDataService.addCache(cache)
                            .success(function () {
                                // reset form fields
                                $scope.name = "";
                                $scope.longitude = "";
                                $scope.latitude = "";

                                $('#add-cache-modal').modal('hide');
                            })
                            .error(function (data) {
                                $scope.formErrors = [];
                                // populate errors
                                var modelKeys = Object.keys(data.ModelState);
                                //loop through invalid properties
                                for (var i = 0; i < modelKeys.length; i++) {
                                    var model = data.ModelState[modelKeys[i]];
                                    //loop through error messages on invalid property
                                    for (var j = 0; j < model.length; j++) {
                                        $scope.formErrors.push(model[j]);
                                    }
                                }
                            });
                    };

                    /* check form for validation errors */
                    $scope.anyErrorsOnForm = function () {
                        $scope.formErrors = [];
                        var errored = false;

                        if ($scope.addCacheForm.name.$error.pattern || 
                            $scope.addCacheForm.name.$error.required) {
                            $scope.formErrors.push("Name must be alphanumeric and between 6-50 characters.");
                            errored = true;
                        }
                        if ($scope.addCacheForm.latitude.$error.required ||
                                    $scope.addCacheForm.latitude.$error.pattern) {
                            $scope.formErrors.push("Latitude is required or is not in a correct format. Must be between -90 and 90.");
                            errored = true;
                        }
                        if ($scope.addCacheForm.longitude.$error.required ||
                                    $scope.addCacheForm.longitude.$error.pattern) {
                            $scope.formErrors.push("Longitude is required or is not in a correct format. Must be between -180 and 180.");
                            errored = true;
                        }

                        return errored;
                    }
                }
            }
        }]);
})();