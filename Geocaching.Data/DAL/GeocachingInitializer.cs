using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Data.DAL
{
    public class GeocachingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GeocachingContext>
    {
        protected override void Seed(GeocachingContext context)
        {
            base.Seed(context);
        }
    }
}
