using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateApiLibrary.Entity
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Password { get; set; } = null!;

        [Required]
        public List<RealEstate> RealEstates { get; set; }
    }
}