namespace RealEstateApiLibrary.Entity
{
    public class Amenities
    {
        public int id { get; set; }
        public string description { get; set; } = null!;
        
        public List<RealEstateHasAmenities> RealEstateHasAmenities { get; set; } = new List<RealEstateHasAmenities>();
    }
}