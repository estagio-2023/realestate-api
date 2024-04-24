using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetAllCustomersAsync();
        Task<CustomerModel> AddCustomerAsync(CustomerRequestDto customerData);
        Task<CustomerModel> GetCustomerByIdAsync(int customerId);
    }
}