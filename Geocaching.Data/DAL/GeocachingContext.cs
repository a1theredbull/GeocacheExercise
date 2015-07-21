using Geocaching.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Data.DAL
{
    public class GeocachingContext : DbContext
    {
        public GeocachingContext() : base("GeocachingContext")
        {
            Database.SetInitializer<GeocachingContext>(new CreateDatabaseIfNotExists<GeocachingContext>());
        }

        public DbSet<Geocache> Geocaches { get; set; }
    }
}
