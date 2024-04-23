namespace RealEstateApi.Dto.Request
{
    public class RealEstateRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int CityId { get; set; }
        public int TypologyId { get; set; }
    }
}
