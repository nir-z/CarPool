using CarPool.EF.DB;
using CarPool.EF.Models;
using CarPool.Enums;
using Microsoft.EntityFrameworkCore;
using System;


namespace CarPool.EF.DB
{
    public class CarPoolDbContext :DbContext
    {

        public string DbPath { get; }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarLease> CarLeases { get; set; }


        public CarPoolDbContext(DbContextOptions<CarPoolDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //          => options.UseSqlite("Data Source=carpool.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // configures one-to-many relationship
            modelBuilder.Entity<Car>()
                .HasOne<Manufacturer>(s => s.Manufacturer)
                .WithMany(g => g.Cars)
                .HasForeignKey(s => s.ManufacturerId);


            modelBuilder.Entity<CarLease>()
            .HasOne(b => b.Car)
            .WithOne(i => i.Lease)
            .HasForeignKey<Car>(b => b.LeaseId);


            modelBuilder.Entity<CarLease>()
             .HasOne(b => b.Driver)
             .WithOne(i => i.Lease)
             .HasForeignKey<Driver>(b => b.LeaseId);


            #region seed data


            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer[] 
            {
                new Manufacturer { Id = 1, Name = "Toyota" },
                 
                new Manufacturer { Id = 2, Name = "Tesla" },
            });

            modelBuilder.Entity<Car>().HasData(new Car[] 
            {
                new Car { Id = 1, Color = ColorsEnums.BLUE, LicenseNumber = "75327301", ManufacturerId = 1, LeaseId = 1 },
            });


            modelBuilder.Entity<Driver>().HasData(new Driver[] 
            {
                new Driver { Id = 1 , FirstName = "Nir", LastName = "Karniel" , LicenseNumber = "48934955", LeaseId = 1 },

            });


            modelBuilder.Entity<CarLease>().HasData(new CarLease[]
            {
               new CarLease  { Id = 1, CarId = 1, DriverId = 1, StartDate = new DateTime (2022, 10 ,19), EndDate = new DateTime(2025, 10, 18) }
            });


            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}