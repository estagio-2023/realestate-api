using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// 
        /// Gather a List of all Customers
        /// 
        /// </summary>
        /// <returns> List<CustomerModel> </returns>
        public async Task<ServiceResult<List<CustomerModel>>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        /// <summary>
        /// 
        /// Creates a Customer
        /// 
        /// </summary>
        /// <param name="customerData"></param>
        /// <returns> CustomerModel </returns>
        public async Task<ServiceResult<CustomerModel>> AddCustomerAsync(CustomerRequestDto customerData)
        {
            return await _customerRepository.AddCustomerAsync(customerData);
        }

        /// <summary>
        /// 
        /// Gets a Customer by Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        public async Task<ServiceResult<CustomerModel>> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        /// <summary>
        /// 
        /// Deletes a Customer by Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        public async Task<ServiceResult<CustomerModel>> DeleteCustomerByIdAsync(int customerId)
        {
            ServiceResult<CustomerModel> response = new();

            var existCustomer = await GetCustomerByIdAsync(customerId);

            if (existCustomer.Result == null)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"Cusomter with ID {customerId} doesn't exist");
                return response;
            }

            response = await _customerRepository.DeleteCustomerByIdAsync(customerId);

            return response;
        }
    }
}