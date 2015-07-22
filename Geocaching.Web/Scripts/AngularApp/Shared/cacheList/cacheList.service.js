(function () {
    "use strict";

    angular.module("GeocachingServices", [])
        .factory("GeocachingDataService", ['$http', 
            function GeocachingDataService($http) {
                function getCaches() {
                    return $http.get(API_URL + "/geocache")
                        .success(function (data) {
                            service.caches = data;

                            //auto-select first cache
                            if (data.length > 0) {
                                service.selectedCache = data[0];
                            }
                        })
                        .error(function (data) {
                            console.error("Error retreiving caches: " + data);
                        });
                }

                function addCache(cache) {
                    return $http.post(API_URL + "/geocache", cache)
                        .success(function (data) {
                            service.caches.push(data);
                        })
                        .error(function(data) {
                            console.error("Error adding cache: " + data);
                        });
                }

                function deleteCache(id) {
                    return $http.delete(API_URL + "/geocache/" + id)
                        .success(function (data) {
                            //manual remove, could $.grep here
                            for (var i = 0; i < service.caches.length; i++) {
                                if (service.caches[i].ID == id) {
                                    service.caches.splice(i, 1);
                                }
                            }
                        })
                        .error(function (data) {
                            console.error("Error deleting cache: " + data);
                        });
                }

                var service = {
                    caches: [],
                    selectedCache: {},
                    getCaches: getCaches,
                    addCache: addCache,
                    deleteCache: deleteCache
                };

                return service;
            }]);
})();