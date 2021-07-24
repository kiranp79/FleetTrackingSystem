using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationApi.Models;
using LocationApi.Models.Repository;

namespace LocationApi.Models.DataManager
{
    public class LocationMaster : IDataRepository<LocationInfo>
    {
        readonly LocationContext _LocationContext;

        public LocationMaster(LocationContext context)
        {
            _LocationContext = context;
        }
        public IEnumerable<LocationInfo> GetAll()
        {
            return _LocationContext.Location.ToList();
        }
        public LocationInfo Get(long id)
        {
            return _LocationContext.Location
                  .FirstOrDefault(o => o.LocationID == id);
        }
        public void Add(LocationInfo entity)
        {
            _LocationContext.Location.Add(entity);
            _LocationContext.SaveChanges();
        }

        public void Update(LocationInfo Location, LocationInfo entity)
        {
            Location.LocationID = entity.LocationID;
            Location.FleetID = entity.FleetID;
            Location.Latitude = entity.Latitude;
            Location.Longitude = entity.Longitude;

            _LocationContext.SaveChanges();
        }
        public void Delete(LocationInfo Location)
        {
            _LocationContext.Location.Remove(Location);
            _LocationContext.SaveChanges();
        }

        //LocationInfo IDataRepository<LocationInfo>.Get(long id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
