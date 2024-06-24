namespace RealEstateLibraryEF.Entity
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int BuildDate { get; set; }
        public decimal Price { get; set; }
        public int SquareMeter { get; set; }
        public string EnergyClass { get; set; } = null!;
        public int CityId { get; set; }
        public int CustomerId { get; set; }
        public int RealEstateTypeId { get; set; }
        public int TypologyId { get; set; }
        public City City { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public RealEstateType RealEstateType { get; set; } = null!;
        public Typology Typology { get; set; } = null!;
        public List<RealEstateHasAmenities> RealEstateHasAmenities { get; set; } = null!;
        public List<VisitRequest> VisitRequests { get; set; } = null!;
    }
}