namespace RealEstateApiLibrary.Entity
{
    public class ReferenceData
    {
        public int id { get; set; }
        public string description { get; set; } = null!;

        public List<RealEstate> RealEstates { get; set; } = new List<RealEstate>();
    }
}