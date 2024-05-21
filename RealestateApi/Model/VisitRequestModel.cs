namespace RealEstateApi.Model
{
    public class VisitRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool Confirmed { get; set; }
        public int FkRealEstateId { get; set; }
        public int FkAgentId { get; set; }
    }
}