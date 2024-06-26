namespace RealEstateApiLibraryEF.Entity
{
    public class RealEstateHasAmenities
    {
        public int Id { get; set; }

        public int RealEstateId { get; set; }

        public int AmenitiesId { get; set; }

        public RealEstate RealEstate { get; set; } = null!;

        public Amenities Amenities { get; set; } = null!;
    }
}