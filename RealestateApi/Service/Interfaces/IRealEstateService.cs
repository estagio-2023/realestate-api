using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IRealEstateService
    {
        Task<ServiceResult<List<RealEstateRequestDto>>> GetAllRealEstateAsync();
        Task<ServiceResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto);
        Task<List<RealEstateRequestDto>> GetAllRealEstateAsync();
        Task<RealEstateModel> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto);
        Task<RealEstateModel> GetRealEstateByIdAsync(int realEstateId);
    }
}