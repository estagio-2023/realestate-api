using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<List<ClientModel>> GetAllCustomersAsync();
    }
}
    