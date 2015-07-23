using Geocaching.API.Filters;
using Geocaching.API.Models;
using Geocaching.Data.DAL;
using Geocaching.Data.Models;
using Geocaching.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Geocaching.API.Controllers
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
        public IEnumerable<GeocacheModel> Get()
        {
            IEnumerable<Geocache> allCaches = _repository.GetAllGeocaches();
            List<GeocacheModel> models = new List<GeocacheModel>();
            // note: could swap out for automapping library
            foreach (var geocache in allCaches)
            {
                models.Add(new GeocacheModel(geocache));
            }
            return models;
        }

        // GET api/geocache/5
        public GeocacheModel Get(long id)
        {
            return new GeocacheModel(_repository.GetGeocacheByID(id));
        }

        // POST api/geocache
        [ValidateModel]
        public GeocacheModel Post([FromBody]GeocacheModel newCache)
        {
            Geocache newDbCache = _repository.AddGeocache(newCache.Map());
            newCache.ID = newDbCache.ID;
            return newCache;
        }

        // DELETE api/geocache/5
        public void Delete(int id)
        {
            _repository.DeleteGeocache(id);
        }
    }
}