namespace RealEstateApiLibrary.Entity
{
    public class RealEstate
    {
        public int id { get; set; }
        public string title { get; set; } = null!;
        public string address { get; set; } = null!;
        public string zip_code { get; set; } = null!;
        public string description { get; set; } = null!;
        public int build_date { get; set; }
        public decimal price { get; set; }
        public int square_meter { get; set; }
        public string energy_class { get; set; } = null!;
        public int city_id { get; set; }
        public int customer_id { get; set; }
        public int realestate_id { get; set; }
        public int typology_id { get; set; }
        public City City { get; set; }
        public Customer Customer { get; set; }
        public RealEstateType RealEstateType { get; set; }
        public Typology Typology { get; set; }

        public List<RealEstateHasAmenities> RealEstateHasAmenities { get; set; } = new List<RealEstateHasAmenities>();
        public List<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();
    }
}