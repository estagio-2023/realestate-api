namespace RealEstateApiLibrary.Entity
{
    public class RealEstateHasAmenities
    {
        public int id { get; set; }
        public int realestate_id { get; set; }
        public int amenities_id { get; set; }

        public RealEstate RealEstate { get; set; }
        public Amenities Amenities { get; set; }
    }
}