namespace EntityFrameworkApiLibrary.Entity
{
    public class City : ReferenceData
    {
        public List<RealEstate> RealEstates { get; set; } = new();
    }
}