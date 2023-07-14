using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolBus.Models.Concretes;

namespace SchoollBusData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Ride> Rides { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-D6KE8CP;Initial Catalog=SchoolBus2Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasOne(student => student.Class)
                        .WithMany(clas => clas.Students)
                        .HasForeignKey(student => student.ClassId);

            modelBuilder.Entity<Parent>()
                        .HasMany(parent => parent.Students)
                        .WithOne(student => student.Parent)
                        .HasForeignKey(student => student.ParentId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                        .HasOne(student => student.Ride)
                        .WithMany(ride => ride.Students)
                        .HasForeignKey(student => student.RideId);

            modelBuilder.Entity<Driver>()
                        .HasOne(driver => driver.Car)
                        .WithOne(car => car.Driver)
                        .HasForeignKey<Driver>(driver => driver.CarId);

            modelBuilder.Entity<Driver>()
                        .HasOne(driver => driver.Ride)
                        .WithOne(ride => ride.Driver)
                        .HasForeignKey<Driver>(driver => driver.RideId);
        }
    }
}
