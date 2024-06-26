namespace RealEstateApiLibraryEF.Entity
{
    public class Amenities : ReferenceData
    {
        public List<RealEstate> RealEstates { get; set; } = null!;
    }
}