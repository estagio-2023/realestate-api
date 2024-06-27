using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Entities
{
    public class RealEstateHasAmenityEntity
    {
        public int Id { get; set; }
        public int RealEstateId { get; set; }
        public int AmenitiesId { get; set; }
        public RealEstateEntity RealEstate { get; set; } = null!;
        public AmenityEntity Amenity { get; set; } = null!;
    }
}
