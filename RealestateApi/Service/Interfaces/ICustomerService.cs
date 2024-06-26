using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;

namespace RealEstateApi.Service.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// 
        /// Gathers a List of all Customer
        /// 
        /// </summary>
        /// <returns> List<CustomerModel> </returns>
        Task<ServiceResult<List<CustomerResponseDto>>> GetAllCustomersAsync();

        /// <summary>
        /// 
        /// Save a Customer
        /// 
        /// </summary>
        /// <param name="customerData"> Customer Data to be Saved </param>
        /// <returns> CustomerModel </returns>
        Task<ServiceResult<CustomerResponseDto>> AddCustomerAsync(CustomerRequestDto customerData);

        /// <summary>
        /// 
        /// Gets a Customer by Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        Task<ServiceResult<CustomerResponseDto>> GetCustomerByIdAsync(int customerId);

        /// <summary>
        /// 
        /// Deletes a Customer By Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        Task<ServiceResult<CustomerResponseDto>> DeleteCustomerByIdAsync(int customerId);
    }
}