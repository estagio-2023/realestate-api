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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var typeDatabase = _configuration["TypeDatabase"];
            var connectionString = _configuration.GetConnectionString(typeDatabase);

            optionsBuilder
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        }

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
            });

            modelBuilder.Entity<VisitRequest>(entity =>
            {
                entity.ToTable("visits_requests");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                .IsRequired();

                entity.Property(e => e.Email)
                .IsRequired();

                entity.Property(e => e.Date)
                .IsRequired();

                entity.Property(e => e.StartTime).HasColumnName("start_time")
                .IsRequired();

                entity.Property(e => e.EndTime).HasColumnName("end_time")
                .IsRequired();

                entity.Property(e => e.Confirmed)
                .IsRequired();

                entity.Property(e => e.AgentId);
           
                entity.Property(e => e.RealEstateId).HasColumnName("realestate_id");
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
                      .IsRequired();

                entity.Property(e => e.Email)
                      .IsRequired();

                entity.Property(e => e.PhoneNumber)
                      .IsRequired();
            });

            modelBuilder.Entity<RealEstateHasAmenities>(entity =>
            {
                entity.ToTable("realestate_has_amenities");
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
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.HasMany(x => x.RealEstates)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsRequired();
            });

            modelBuilder.Entity<Customer>(entity =>
            {

                entity.ToTable("customers");

                entity.HasMany(x => x.RealEstates)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RealEstateType>(entity =>
            {
                entity.ToTable("realestate_types");

                entity.HasMany(x => x.RealEstates)
                .WithOne(x => x.RealEstateType)
                .HasForeignKey(x => x.RealEstateTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Typology>(entity =>
            {
                entity.ToTable("typologies");

                entity.HasMany(x => x.RealEstates)
                .WithOne(x => x.Typology)
                .HasForeignKey(x => x.TypologyId)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}