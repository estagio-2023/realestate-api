using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<ServiceResult<List<CustomerModel>>> GetAllCustomersAsync();
        Task<ServiceResult<CustomerModel>> AddCustomerAsync(CustomerRequestDto customerData);
        Task<ServiceResult<CustomerModel>> GetCustomerByIdAsync(int customerId);
    }
}