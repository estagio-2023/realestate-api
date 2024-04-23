using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IRealEstateService
    {
        Task<List<RealEstateRequestDto>> GetAllRealEstateAsync();
    }
}
