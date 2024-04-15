using RealEstateApi.Model;

namespace RealEstateApi.Dto.Response
{
    public class AddReferenceDataResponseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
    }
}