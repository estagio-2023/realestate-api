using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IRealEstateService
    {
        Task<List<RealEstateModel>> GetAllRealEstateAsync();
    }
}
