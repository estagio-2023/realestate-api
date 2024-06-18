using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateApiLibrary.Entity;

namespace RealEstateApiLibrary.DataAccess
{
    public class RealEstateContext : DbContext
    {
        public IConfiguration _configuration;

        public RealEstateContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var typeDatabase = _configuration["TypeDatabase"];
            var connectionString = _configuration.GetConnectionString(typeDatabase);

            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customeres { get; set; }
        public DbSet<RealEstateHasAmenities> Realestate_has_amenities { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstateType> Realestate_types { get; set; }
        public DbSet<Typology> Typologies { get; set; }
        public DbSet<VisitRequest> Visit_requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().HasMany(x => x.VisitRequests).WithOne(x => x.Agent).HasForeignKey(x => x.AgentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RealEstate>().HasMany(x => x.VisitRequests).WithOne(x => x.RealEstate).HasForeignKey(x => x.RealEstateId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RealEstate>().HasMany(x => x.RealEstateHasAmenities).WithOne(x => x.RealEstate).HasForeignKey(x => x.RealEstateId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Amenities>().HasMany(x => x.RealEstateHasAmenities).WithOne(x => x.Amenities).HasForeignKey(x => x.AmenitiesId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<City>().HasMany(x => x.RealEstates).WithOne(x => x.City).HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasMany(x => x.RealEstates).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RealEstateType>().HasMany(x => x.RealEstates).WithOne(x => x.RealEstateType).HasForeignKey(x => x.RealEstateTypeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Typology>().HasMany(x => x.RealEstates).WithOne(x => x.Typology).HasForeignKey(x => x.TypologyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}