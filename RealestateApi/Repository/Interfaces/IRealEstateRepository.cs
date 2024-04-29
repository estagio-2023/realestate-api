using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Service;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IRealEstateRepository
    {
        Task<ServiceResult<List<RealEstateRequestDto>>> GetAllRealEstateAsync();
        Task<ServiceResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto);
    }
}