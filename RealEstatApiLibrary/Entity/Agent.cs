namespace RealEstateApiLibrary.Entity
{
    public class Agent
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }

        public List<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();
    }
}