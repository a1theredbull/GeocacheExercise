using Geocaching.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Data.Models
{
    public class Geocache : BaseGeocache
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long ID { get; set; }

        public Geocache()
        {
        }

        public Geocache(IGeocache geocache)
        {
            this.ID = geocache.ID;
            this.Name = geocache.Name;
            this.Latitude = geocache.Latitude;
            this.Longitude = geocache.Longitude;
        }
    }
}
