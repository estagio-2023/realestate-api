namespace EFLibrary.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int SquareMeter { get; set; }
        public char EnergyClass { get; set; }
        public int BuildDate { get; set; }
    }
}
