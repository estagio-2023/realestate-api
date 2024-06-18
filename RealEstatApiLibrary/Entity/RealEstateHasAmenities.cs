using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApiLibrary.Entity
{
    public class RealEstateHasAmenities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RealEstateId { get; set; }

        [Required]
        public int AmenitiesId { get; set; }

        public RealEstate RealEstate { get; set; }
        public Amenities Amenities { get; set; }
    }
}