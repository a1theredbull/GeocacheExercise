using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocaching.Domain.Repository
{
    public interface IGeocacheRepository
    {
        IEnumerable<IGeocache> GetAllGeocaches();
        IGeocache GetGeocacheByID(long id);
        IGeocache AddGeocache(IGeocache geocache);
        void DeleteGeocache(long id);
        bool IsUniqueName(string name);
    }
}
