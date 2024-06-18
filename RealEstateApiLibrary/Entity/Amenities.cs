using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApiLibrary.Entity
{
    public class Amenities
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; set; } = null!;

        [Required]
        public List<RealEstateHasAmenities> RealEstateHasAmenities { get; set; }
    }
}