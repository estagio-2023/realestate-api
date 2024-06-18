using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateApiLibrary.Entity
{
    public class RealEstate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(8)]
        [Column(TypeName = "varchar(8)")]
        public string ZipCode { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; } = null!;

        [Required]
        public int BuildDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        [Required]
        public int SquareMeter { get; set; }

        [Required]
        [Column(TypeName = "char")]
        public string EnergyClass { get; set; } = null!;

        [Required]
        public int CityId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int RealEstateTypeId { get; set; }

        [Required]
        public int TypologyId { get; set; }

        public City City { get; set; }
        public Customer Customer { get; set; }
        public RealEstateType RealEstateType { get; set; }
        public Typology Typology { get; set; }

        [Required]
        public List<RealEstateHasAmenities> RealEstateHasAmenities { get; set; }

        [Required]
        public List<VisitRequest> VisitRequests { get; set; }
    }
}