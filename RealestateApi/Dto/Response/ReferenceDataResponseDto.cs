namespace RealEstateApi.Dto.Response
{
    public class ReferenceDataResponseDto
    {
        public List<ReferenceDataDto> Amenities { get; set; }

        public List<ReferenceDataDto> Cities { get; set; }

        public List<ReferenceDataDto> Typologies { get; set; }

        public List<ReferenceDataDto> RealEstateTypes { get; set; }
    }
}