using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateApiLibrary.Entity
{
    public class Agent
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(13)]
        [Column(TypeName = "varchar(13)")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; }

        [Required]
        public List<VisitRequest> VisitRequests { get; set; }
    }
}