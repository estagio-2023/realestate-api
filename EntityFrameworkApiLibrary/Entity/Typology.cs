namespace EntityFrameworkApiLibrary.Entity
{
    public class Typology : ReferenceData
    {
        public List<RealEstate> RealEstates { get; set; } = new();
    }
}