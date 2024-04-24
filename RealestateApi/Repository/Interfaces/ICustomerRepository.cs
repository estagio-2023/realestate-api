using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Service;

namespace RealEstateApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ServiceResult<List<CustomerModel>>> GetAllCustomersAsync();
        Task<CustomerModel> AddCustomerAsync(CustomerRequestDto customerData);
        Task<CustomerModel> GetCustomerByIdAsync(int customerId);
    }
}