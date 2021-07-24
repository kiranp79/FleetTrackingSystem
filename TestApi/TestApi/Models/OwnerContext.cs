using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models
{
    public class OwnerContext : DbContext
    {
        public OwnerContext(DbContextOptions<OwnerContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<OwnerData> Owners { get; set; }
        //public DbSet<FleetData> Fleets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerData>().HasData(new OwnerData
            {
                OwnerId = 101,
                OwnerName = "Bob",
                OwnerContact = 64737493,
                OwnerEmail = "qnwqn2@feen",
                Ownerpass = "cbdcmbs"

            }, new OwnerData
            {

                OwnerId = 102,
                OwnerName = "malkdm",
                OwnerContact = 64737493,
                OwnerEmail = "qnwcsmklcm@feen",
                Ownerpass = "cbadjwu89bs"
            }); 
        }
    }
}
