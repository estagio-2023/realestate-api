using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IRealEstateRepository
    {
        Task<RealEstateResponseDto> GetRealEstateAsync();

    }
}
