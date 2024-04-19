using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IRealEstateService
    {
        Task<List<RealEstate>> GetAllRealEstateAsync();
        Task<RealEstate> AddRealEstateAsync(AddRealEstateRequestDto realEstateData);
    }
}
