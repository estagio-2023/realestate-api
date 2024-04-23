using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IRealEstateService
    {
        Task<List<RealEstateRequestDto>> GetAllRealEstateAsync();
        Task<RealEstateModel> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto);
        Task<RealEstateModel> GetRealEstateByIdAsync(int realEstateId);
    }
}