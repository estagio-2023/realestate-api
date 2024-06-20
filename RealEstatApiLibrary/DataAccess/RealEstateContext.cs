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

            if (typeDatabase == "Mysql")
            {
                optionsBuilder.UseMySQL(connectionString);
            }
            else if (typeDatabase == "Postgresql")
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbSet<Agent> agents { get; set; }
        public DbSet<Amenities> amenities { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<RealEstateHasAmenities> realestate_has_amenities { get; set; }
        public DbSet<RealEstate> realestates { get; set; }
        public DbSet<RealEstateType> realestate_types { get; set; }
        public DbSet<Typology> typologies { get; set; }
        public DbSet<VisitRequest> visit_requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>()
                .HasMany(x => x.VisitRequests)
                .WithOne(x => x.Agent)
                .HasForeignKey(x => x.agent_id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RealEstate>()
                .HasMany(x => x.VisitRequests)
                .WithOne(x => x.RealEstate)
                .HasForeignKey(x => x.realestate_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RealEstate>()
                .HasMany(x => x.RealEstateHasAmenities)
                .WithOne(x => x.RealEstate)
                .HasForeignKey(x => x.realestate_id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Amenities>()
                .HasMany(x => x.RealEstateHasAmenities)
                .WithOne(x => x.Amenities)
                .HasForeignKey(x => x.amenities_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<City>()
                .HasMany(x => x.RealEstates)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.city_id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>()
                .HasMany(x => x.RealEstates)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.customer_id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RealEstateType>()
                .HasMany(x => x.RealEstates)
                .WithOne(x => x.RealEstateType)
                .HasForeignKey(x => x.realestate_id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Typology>()
                .HasMany(x => x.RealEstates)
                .WithOne(x => x.Typology)
                .HasForeignKey(x => x.typology_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}