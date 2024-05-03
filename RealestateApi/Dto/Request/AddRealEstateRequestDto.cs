namespace RealEstateApi.Dto.Request
{
    public class AddRealEstateRequestDto
    {
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Build_Date { get; set; }
        public decimal Price { get; set; }
        public int SquareMeter { get; set; }
        public string EnergyClass { get; set; } = null!;
        public int CustomerId { get; set; }
        public int AgentId { get; set; }
        public int RealEstateTypeId { get; set; }
        public int CityId { get; set; }
        public int TypologyId { get; set; }
    }
}