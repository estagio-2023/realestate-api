using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApiLibrary.Entity
{
    public class Typology
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; } = null!;

        [Required]
        public List<RealEstate> RealEstates { get; set; }
    }
}