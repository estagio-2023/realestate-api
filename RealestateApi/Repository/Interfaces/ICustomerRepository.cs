using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Service;

namespace RealEstateApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ServiceResult<List<CustomerModel>>> GetAllCustomersAsync();
        Task<ServiceResult<CustomerModel>> AddCustomerAsync(CustomerRequestDto customerData);
        Task<ServiceResult<CustomerModel>> GetCustomerByIdAsync(int customerId);
    }
}