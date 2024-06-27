namespace EntityFrameworkApiLibrary.Entity
{
    public class Amenities : ReferenceData
    {
       public List<RealEstateHasAmenities> RealEstateHasAmenities { get; set; } = new();
    }
}