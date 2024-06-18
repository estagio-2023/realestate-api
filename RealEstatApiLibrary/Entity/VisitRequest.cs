using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateApiLibrary.Entity
{
    public class VisitRequest
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateOnly Date { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan EndTime { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        public bool Confirmed { get; set; }

        [Required]
        public int AgentId { get; set; }

        [Required]
        public int RealEstateId { get; set; }
        public Agent Agent { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}