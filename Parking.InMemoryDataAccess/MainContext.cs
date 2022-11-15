using Microsoft.EntityFrameworkCore;
using Parking.Domain.Enums;
using Parking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.InMemoryDataAccess
{
    public class MainContext : DbContext
    {
        public MainContext()
        {
            Database.EnsureCreated();
        }


        public DbSet<ParkingSpace> Parkings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ParkingDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>().HasData(new ParkingSpace { Id = 1, Address = "Yasmin St 334" });
            modelBuilder.Entity<ParkingSpace>().HasData(new ParkingSpace { Id = 2, Address = "Hovevei Tsiyon St 324" });
            modelBuilder.Entity<ParkingSpace>().HasData(new ParkingSpace { Id = 3, Address = "Tsvi Bornstein St 1" });
            modelBuilder.Entity<ParkingSpace>().HasData(new ParkingSpace { Id = 4, Address = "Elkahayel 171" });
        }
    }
}
