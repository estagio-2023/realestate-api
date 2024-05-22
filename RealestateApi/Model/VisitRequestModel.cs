namespace RealEstateApi.Model
{
    public class VisitRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Confirmed { get; set; }
        public int FkRealEstateId { get; set; }
        public int FkAgentId { get; set; }
    }
}