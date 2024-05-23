namespace RealEstateApi.Dto.Request
{
    public class VisitRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string  StartTime { get; set; }
        public string EndTime { get; set; }
        public int FkRealEstateId { get; set; }
        public int FkAgentId { get; set; }
    }
}
