(function () {
    "use strict";

    angular.module("GeocachingServices", [])
        .factory("GeocachingDataService", ['$http', 
            function GeocachingDataService($http) {
                function getCaches() {
                    return $http.get(API_URL + "/geocache")
                        .success(function (data) {
                            service.caches = data;
                        })
                        .error(function (data) {
                            console.error("Error retreiving caches: " + data);
                        });
                }

                function addCache(cache) {
                    return $http.post(API_URL + "/geocache", cache)
                        .success(function (data) {
                            getCaches();
                        })
                        .error(function(data) {
                            console.error("Error adding cache: " + data);
                            getCaches();
                        });
                }

                function deleteCache(id) {
                    return $http.delete(API_URL + "/geocache/" + id)
                        .success(function (data) {
                            getCaches();
                        })
                        .error(function (data) {
                            console.error("Error deleting cache: " + data);
                            getCaches();
                        });
                }

                var service = {
                    caches: [],
                    getCaches: getCaches,
                    addCache: addCache,
                    deleteCache: deleteCache
                };

                return service;
            }]);
})();