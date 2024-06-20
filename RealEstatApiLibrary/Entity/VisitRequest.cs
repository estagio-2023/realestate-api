namespace RealEstateApiLibrary.Entity
{
    public class VisitRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateOnly date { get; set; }
        public TimeSpan start_time { get; set; }
        public TimeSpan end_time { get; set; }
        public bool confirmed { get; set; }
        public int agent_id { get; set; }
        public int realestate_id { get; set; }

        public Agent Agent { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}