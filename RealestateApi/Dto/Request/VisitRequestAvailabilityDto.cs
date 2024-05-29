namespace RealEstateApi.Dto.Request
{
    public class VisitRequestAvailabilityDto
    {
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int FkRealEstateId { get; set; }
        public int FkAgentId { get; set; }

        public static VisitRequestAvailabilityDto BuildFrom(string date, string startTime, string endTime, int realEstateId, int agentId)
        {
            return new VisitRequestAvailabilityDto { FkRealEstateId = realEstateId, FkAgentId = agentId, Date = date, EndTime = endTime, StartTime=startTime  };          
        }
    }
}
