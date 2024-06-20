namespace RealEstateApiLibrary.Entity
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string email { get; set; } = null!;
        public string Password { get; set; } = null!;
        
        public List<RealEstate> RealEstates { get; set; } = new List<RealEstate>();
    }
}