using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<List<ClientModel>> GetAllCustomersAsync();
        Task<ClientModel> AddCustomerAsync(CustomerRequestDto customerData);
    }
}