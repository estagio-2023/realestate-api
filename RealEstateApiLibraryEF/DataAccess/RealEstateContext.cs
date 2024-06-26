using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RealEstateApiLibraryEF.Entity;

namespace RealEstateApiLibraryEF.DataAccess
{
    public class RealEstateContext : DbContext
    {
        public IConfiguration _configuration;

        public RealEstateContext(DbContextOptions<RealEstateContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
         
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RealEstateHasAmenities> RealEstateHasAmenities { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }
        public DbSet<Typology> Typologies { get; set; }
        public DbSet<VisitRequest> VisitRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenities>(entity =>
            {
                entity.ToTable("amenities");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsRequired();
            });

            modelBuilder.Entity<VisitRequest>(entity =>
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

            modelBuilder.Entity<Agent>(entity =>
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

            modelBuilder.Entity<RealEstate>(entity =>
            {
                entity.ToTable("real_estates");

                entity.HasMany(x => x.RealEstateHasAmenities)
                .WithOne(x => x.RealEstate)
                .HasForeignKey(x => x.RealEstateId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.VisitRequests)
                .WithOne(x => x.RealEstate)
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

            modelBuilder.Entity<City>(entity =>
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

            modelBuilder.Entity<Customer>(entity =>
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

            modelBuilder.Entity<RealEstateType>(entity =>
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

            modelBuilder.Entity<Typology>(entity =>
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