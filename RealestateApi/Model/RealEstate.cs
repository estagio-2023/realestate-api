namespace RealEstateApi.Model
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public DateTime Build_Date { get; set; }
        public decimal Price { get; set; }     
        public int SquareMeter { get; set; }
        public string EnergyClass { get; set; } = null!;
        public int ClientId { get; set; }
        public int AgentId { get; set; }
        public int RealEstateTypeId { get; set; }
        public int CityId { get; set; }
        public int TypologyId { get; set; }
    }
}