using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

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
        Task<ServiceResult<List<CustomerModel>>> GetAllCustomersAsync();

        /// <summary>
        /// 
        /// Save a Customer
        /// 
        /// </summary>
        /// <param name="customerData"> Customer Data to be Saved </param>
        /// <returns> CustomerModel </returns>
        Task<ServiceResult<CustomerModel>> AddCustomerAsync(CustomerRequestDto customerData);

        /// <summary>
        /// 
        /// Gets a Customer by Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        Task<ServiceResult<CustomerModel>> GetCustomerByIdAsync(int customerId);

        /// <summary>
        /// 
        /// Deletes a Customer By Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        Task<ServiceResult<CustomerModel>> DeleteCustomerByIdAsync(int customerId);
    }
}