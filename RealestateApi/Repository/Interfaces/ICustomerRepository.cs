using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetAllCustomersAsync();
        Task<CustomerModel> AddCustomerAsync(CustomerRequestDto customerData);
    }
}