namespace RealEstateApiLibraryEF.Entity
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public List<RealEstate> RealEstates { get; set; } = null!;
    }
}