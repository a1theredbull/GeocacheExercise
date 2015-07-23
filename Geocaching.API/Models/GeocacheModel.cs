using Geocaching.API.Filters;
using Geocaching.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Geocaching.API.Models
{
    public class GeocacheModel
    {
        public long ID { get; set; }
        [Required]
        [StringLength(50)]
        [UniqueGeocacheName]
        public string Name { get; set; }
        [Required]
        [Range(-180, 180)]
        public decimal Longitude { get; set; }
        [Required]
        [Range(-90, 90)]
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