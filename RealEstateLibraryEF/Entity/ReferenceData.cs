namespace RealEstateLibraryEF.Entity
{
    public class ReferenceData
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public List<RealEstate> RealEstates { get; set; } = null!;
    }
}