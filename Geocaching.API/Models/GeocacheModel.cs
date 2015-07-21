using Geocaching.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geocaching.API.Models
{
    public class GeocacheModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public GeocacheModel(Geocache geocache)
        {
            if(geocache != null)
            {
                this.ID = geocache.ID;
                this.Name = geocache.Name;
                this.Longitude = geocache.Longitude;
                this.Latitude = geocache.Latitude;
            }
        }

        public Geocache Map()
        {
            Geocache geocache = new Geocache()
            {
                ID = this.ID,
                Name = this.Name,
                Longitude = this.Longitude,
                Latitude = this.Latitude
            };

            return geocache;
        }
    }
}