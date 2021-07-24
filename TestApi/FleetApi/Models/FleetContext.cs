using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetApi.Models
{
    public class FleetContext : DbContext
    {
        public FleetContext(DbContextOptions<FleetContext> options) : base(options)
        {
            Database.Migrate();
        }
       // public DbSet<OwnerData> Owners { get; set; }
        public DbSet<FleetData> Fleets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FleetData>().HasData(new FleetData
            {
                FleetID = 1,
                FleetRCNo = "skfh232fke",
                FleetType = "Car",
                CompanyName = "ssjfksef",
                OwnerId = 101

            }, new FleetData
            {
                FleetID = 2,
                FleetRCNo = "wdswnkj23546lks",
                FleetType = "Truck",
                CompanyName = "sfhjhsfr",
                OwnerId = 101
            });
        }
    }
}
