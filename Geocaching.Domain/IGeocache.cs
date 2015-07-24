using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Domain
{
    public interface IGeocache
    {
        long ID { get; set; }
        string Name { get; set; }
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }
}
