using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Data.Models;
using Geocaching.Data.DAL;
using Geocaching.Domain.Repository;
using Geocaching.Domain;

namespace Geocaching.Data.Repository.Implementation
{
    public class GeocacheRepository : IGeocacheRepository, IDisposable
    {
        private GeocachingContext db = new GeocachingContext();

        #region Repository actions
        public IGeocache AddGeocache(IGeocache geocache)
        {
            Geocache newGeocache = new Geocache(geocache);
            db.Geocaches.Add(newGeocache);
            db.SaveChanges();
            geocache.ID = newGeocache.ID;

            return geocache;
        }

        public void DeleteGeocache(long id)
        {
            IGeocache cacheToRemove = GetGeocacheByID(id);
            db.Geocaches.Remove((Geocache)cacheToRemove);
            db.SaveChanges();
        }

        public IEnumerable<IGeocache> GetAllGeocaches()
        {
            return db.Geocaches.AsEnumerable();
        }

        public IGeocache GetGeocacheByID(long id)
        {
            return db.Geocaches.FirstOrDefault(x => x.ID == id);
        }

        public bool IsUniqueName(string name)
        {
            return !db.Geocaches.Any(x => x.Name == name);
        }
        #endregion

        #region Disposal
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
