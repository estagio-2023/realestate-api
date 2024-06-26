namespace RealEstateApiLibraryEF.Entity
{
    public class RealEstateType : ReferenceData
    {
        public List<RealEstate> RealEstates { get; set; } = null!;
    }
}