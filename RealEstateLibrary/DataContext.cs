using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RealEstateLibrary.Entities;

namespace RealEstateLibrary
{
    public class DataContext : DbContext
    {
        public IConfiguration _configuration;

        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        public DbSet<CityEntity> City {  get; set; } 
        public DbSet<TypologyEntity> Typology {  get; set; }
        public DbSet<RealEstateTypeEntity> RealEstateType {  get; set; }
        public DbSet<AmenityEntity> Amenity {  get; set; }
        public DbSet<CustomerEntity> Customer {  get; set; }
        public DbSet<AgentEntity> Agent {  get; set; }
        public DbSet<RealEstateEntity> RealEstates {  get; set; }
        public DbSet<VisitRequestEntity> VisitRequest {  get; set; }
        public DbSet<RealEstateHasAmenityEntity> RealEstateHasAmenities {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmenityEntity>(entity =>
            {
                entity.ToTable("amenities");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsRequired();
            });

            modelBuilder.Entity<VisitRequestEntity>(entity =>
            {
                entity.ToTable("visits_requests");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsRequired();

                entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsRequired();

                entity.Property(e => e.Date)
                .IsRequired();

                entity.Property(e => e.StartTime)
                .IsRequired();

                entity.Property(e => e.EndTime)
                .IsRequired();

                entity.Property(e => e.Confirmed)
                .IsRequired();

                entity.Property(e => e.AgentId)
                .IsRequired();

                entity.Property(e => e.RealEstateId)
                .IsRequired();
            });

            modelBuilder.Entity<AgentEntity>(entity =>
            {
                entity.ToTable("agents");

                entity.HasMany(x => x.VisitRequests)
                      .WithOne(x => x.Agent)
                      .HasForeignKey(x => x.AgentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(e => e.PhoneNumber)
                      .HasMaxLength(13)
                      .IsRequired();
            });

            modelBuilder.Entity<RealEstateEntity>(entity =>
            {
                entity.ToTable("real_estates");

                 entity.HasMany(x => x.RealEstateHasAmenities)
                .WithOne(x => x.RealEstate)
                .HasForeignKey(x => x.RealEstateId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.VisitRequests)
                .WithOne(x => x.RealEstates)
                .HasForeignKey(x => x.RealEstateId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Address)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.ZipCode)
                      .HasMaxLength(8)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.BuildDate)
                      .IsRequired();

                entity.Property(e => e.Price)
                      .HasPrecision(8, 2)
                      .IsRequired();

                entity.Property(e => e.SquareMeter)
                      .IsRequired();

                entity.Property(e => e.EnergyClass)
                      .HasMaxLength(1)
                      .IsRequired();

                entity.Property(e => e.CustomerId)
                      .IsRequired();

                entity.Property(e => e.RealEstateTypeId)
                      .IsRequired();

                entity.Property(e => e.CityId)
                      .IsRequired();

                entity.Property(e => e.TypologyId)
                      .IsRequired();

            });

            modelBuilder.Entity<CityEntity>(entity =>
            {
                entity.ToTable("cities");

                entity.HasMany(x => x.RealEstates)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsRequired();
            });

            modelBuilder.Entity<CustomerEntity>(entity =>
            {
                entity.ToTable("customers");

                entity.HasMany(x => x.RealEstates)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(e => e.Password)
                      .HasMaxLength(150)
                      .IsRequired();
            });

            modelBuilder.Entity<RealEstateTypeEntity>(entity =>
            {
                entity.ToTable("realestate_types");

                entity.HasMany(x => x.RealEstates)
                .WithOne(x => x.RealEstateType)
                .HasForeignKey(x => x.RealEstateTypeId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsRequired();
            });

            modelBuilder.Entity<TypologyEntity>(entity =>
            {
                entity.ToTable("typologies");

                entity.HasMany(x => x.RealEstates)
                .WithOne(x => x.Typology)
                .HasForeignKey(x => x.TypologyId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsRequired();
            });
        }
    }
}