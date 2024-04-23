using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IRealEstateRepository
    {
        Task<List<RealEstateRequestDto>> GetAllRealEstateAsync();
        Task<RealEstateModel> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto);
    }
}