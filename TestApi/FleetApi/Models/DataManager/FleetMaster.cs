using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetApi.Models;
using FleetApi.Models.Repository;

namespace TestApi.Models.DataManager
{
    public class FleetMaster : IDataRepository<FleetData>
    {
        readonly FleetContext _fleetContext;

        public FleetMaster(FleetContext context)
        {
            _fleetContext = context;
        }
        public IEnumerable<FleetData> GetAll()
        {
            return _fleetContext.Fleets.ToList();
        }
        public FleetData Get(long id)
        {
            return _fleetContext.Fleets
                  .FirstOrDefault(o => o.FleetID == id);
        }
        public void Add(FleetData entity)
        {
            _fleetContext.Fleets.Add(entity);
            _fleetContext.SaveChanges();
        }

        public void Update(FleetData fleet, FleetData entity)
        {
            fleet.FleetID = entity.FleetID;
            fleet.FleetRCNo = entity.FleetRCNo;
            fleet.FleetType = entity.FleetType;
            fleet.CompanyName = entity.CompanyName;
            fleet.OwnerId = entity.OwnerId;

            _fleetContext.SaveChanges();
        }
        public void Delete(FleetData fleet)
        {
            _fleetContext.Fleets.Remove(fleet);
            _fleetContext.SaveChanges();
        }

        

        
    }
}
