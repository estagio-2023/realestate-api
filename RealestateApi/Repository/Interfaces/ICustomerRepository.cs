using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Service;

namespace RealEstateApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// 
        /// Gather a List of all Customers
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
        /// Deletes a Customer by Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        Task<ServiceResult<CustomerModel>> DeleteCustomerByIdAsync(int customerId);
    }
}