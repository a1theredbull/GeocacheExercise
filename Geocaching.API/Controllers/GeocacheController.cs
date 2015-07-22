﻿using Geocaching.API.Models;
using Geocaching.Data.DAL;
using Geocaching.Data.Models;
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
        // TODO: Dependency Inject Repo
        public GeocacheController()
        {

        }

        // GET api/<controller>
        public IEnumerable<GeocacheModel> Get()
        {
            using (GeocachingContext db = new GeocachingContext())
            {
                List<GeocacheModel> models = new List<GeocacheModel>();
                foreach(var geocache in db.Geocaches.AsEnumerable())
                {
                    models.Add(new GeocacheModel(geocache));
                }
                return models;
            }
        }

        // GET api/<controller>/5
        public GeocacheModel Get(long id)
        {
            using(GeocachingContext db = new GeocachingContext())
            {
                GeocacheModel model = new GeocacheModel(db.Geocaches.FirstOrDefault(x => x.ID == id));
                return model;
            }
        }

        // POST api/<controller>
        public GeocacheModel Post([FromBody]GeocacheModel newCache)
        {
            using (GeocachingContext db = new GeocachingContext())
            {
                Geocache newDbCache = db.Geocaches.Add(newCache.Map());
                db.SaveChanges();
                newCache.ID = newDbCache.ID;

                return newCache; 
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (GeocachingContext db = new GeocachingContext())
            {
                Geocache cacheToRemove = db.Geocaches.FirstOrDefault(x => x.ID == id);
                db.Geocaches.Remove(cacheToRemove);
                db.SaveChanges();
            }
        }
    }
}