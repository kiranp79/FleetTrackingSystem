using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationApi.Models
{
    public class LocationContext : DbContext
    {

        public LocationContext(DbContextOptions<LocationContext> options) : base(options)
        {
            Database.Migrate();
        }
        // public DbSet<OwnerData> Owners { get; set; }
        public DbSet<LocationInfo> Location{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationInfo>().HasData(new LocationInfo
            {
                LocationID = 1,
                FleetID = 1,
                Latitude = 23.235323,
                Longitude = 90.392723

            }, new LocationInfo
            {
                LocationID = 2,
                FleetID = 2,
                Latitude = 53.235323,
                Longitude = 73.472922

            }); 
        }

    }
}
