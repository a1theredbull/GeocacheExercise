using Geocaching.Rest.Filters;
using Geocaching.Rest.Models;
using Geocaching.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Geocaching.Domain.Repository;
using Geocaching.Domain;

namespace Geocaching.Rest.Controllers
{
    [EnableCors(origins: "http://localhost:56216", headers: "*", methods: "*")]
    public class GeocacheController : ApiController
    {
        private IGeocacheRepository _repository;

        public GeocacheController(IGeocacheRepository repository)
        {
            _repository = repository;
        }

        // GET api/geocache
        public HttpResponseMessage Get()
        {
            try
            {
                IEnumerable<IGeocache> allCaches = _repository.GetAllGeocaches();
                List<GeocacheModel> models = new List<GeocacheModel>();
                foreach (var geocache in allCaches)
                {
                    models.Add(new GeocacheModel(geocache));
                }
                return Request.CreateResponse(HttpStatusCode.OK, models);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET api/geocache/5
        public HttpResponseMessage Get(long id)
        {
            try
            {
                var foundCache = _repository.GetGeocacheByID(id);
                if(foundCache != null)
                {
                    var foundCacheModel = new GeocacheModel(foundCache);
                    return Request.CreateResponse(HttpStatusCode.OK, foundCacheModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/geocache
        [ValidateModel]
        public HttpResponseMessage Post([FromBody]GeocacheModel newCache)
        {
            try
            {
                IGeocache newDbCache = _repository.AddGeocache(newCache.MapToRepoModel());
                newCache.ID = newDbCache.ID;
                return Request.CreateResponse(HttpStatusCode.OK, newCache);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/geocache/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var foundCache = _repository.GetGeocacheByID(id);
                if (foundCache == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                _repository.DeleteGeocache(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}