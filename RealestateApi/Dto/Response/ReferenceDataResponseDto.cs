using RealEstateApi.Model;

namespace RealEstateApi.Dto.Response
{
    public class ReferenceDataResponseDto
    {
        public List<TypologyModel> Typologies { get; set; } = new();
        public List<RealEstateTypeModel> RealEstateTypes { get; set; } = new();
        public List<CityModel> Cities { get; set; } = new();
        public List<AmenitiesModel> Amenities { get; set; } = new();
    }
}
