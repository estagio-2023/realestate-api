using RealEstateApi.Model;

namespace RealEstateApi.Dto.Response
{
    public class ReferenceDataResponseDto
    {
        public List<TypologyModel> TypologiesList { get; set; } = new();
        public List<RealEstateTypeModel> RealEstateTypesList { get; set; } = new();
        public List<CityModel> CitiesList { get; set; } = new();
        public List<AmenitiesModel> AmenitiesList { get; set; } = new();
    }
}
