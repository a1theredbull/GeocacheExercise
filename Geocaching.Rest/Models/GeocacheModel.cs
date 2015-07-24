using Geocaching.Rest.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Geocaching.Domain;
using Geocaching.Repository.Models;

namespace Geocaching.Rest.Models
{
    public class GeocacheModel
    {
        public long ID { get; set; }
        [Required]
        [UniqueGeocacheName]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(-180, 180)]
        public decimal Longitude { get; set; }
        [Required]
        [Range(-90, 90)]
        public decimal Latitude { get; set; }

        public GeocacheModel(IGeocache geocache)
        {
            if(geocache != null)
            {
                this.ID = geocache.ID;
                this.Name = geocache.Name;
                this.Longitude = geocache.Longitude;
                this.Latitude = geocache.Latitude;
            }
        }

        public IGeocache MapToRepoModel()
        {
            IGeocache geocache = new RepoGeocache()
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