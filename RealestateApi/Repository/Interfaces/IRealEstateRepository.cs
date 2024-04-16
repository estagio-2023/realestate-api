using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IRealEstateRepository
    {
        Task<List<RealEstate>> GetAllRealEstateAsync();
        Task<List<RealEstate>> AddRealEstateAsync(AddRealEstateRequestDto realEstateData);
    }
}
