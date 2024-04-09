using RealEstateApi.Dto.Response;

namespace RealEstateApi.Service.Interfaces
{
    public interface IRealEstateService
    {
        Task<RealEstateResponseDto> GetRealEstateAsync();
    }
}
