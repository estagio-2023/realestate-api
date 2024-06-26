namespace RealEstateApiLibraryEF.Entity
{
    public class Agent
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public List<VisitRequest> VisitRequests { get; set; }
    }
}