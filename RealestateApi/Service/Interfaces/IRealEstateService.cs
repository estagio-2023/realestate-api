using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IRealEstateService
    {
        Task<List<RealEstate>> GetAllRealEstateAsync();
        Task<List<RealEstate>> AddRealEstateAsync(AddRealEstateRequestDto realEstateData);
    }
}
