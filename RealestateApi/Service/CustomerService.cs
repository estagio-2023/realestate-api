using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRealEstateRepository _realEstateRepository;

        public CustomerService(ICustomerRepository customerRepository, IRealEstateRepository realEstateRepository)
        {
            _customerRepository = customerRepository;
            _realEstateRepository = realEstateRepository;
        }

        /// <summary>
        /// 
        /// Gather a List of all Customers
        /// 
        /// </summary>
        /// <returns> List<CustomerModel> </returns>
        public async Task<ServiceResult<List<CustomerModel>>> GetAllCustomersAsync()
        {
            ServiceResult<List<CustomerModel>> response = new();

            try
            {
                var result = await _customerRepository.GetAllCustomersAsync();

                response.Result = result;
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add("There was an error while trying to retrieve all customers.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
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
            ServiceResult<CustomerModel> response = new();

            try
            {
                var result = await _customerRepository.GetCustomerByIdAsync(customerId);

                if (result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Customer ID {customerId} was not found.");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to get customer ID: {customerId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
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
            ServiceResult<CustomerModel> response = new();

            try
            {
                var result = await _customerRepository.AddCustomerAsync(customerData);

                if(result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to add customer {customerData.Name}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
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

            try
            {
                var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customerId);

                if (existingCustomer == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Customer ID {customerId} was not found");
                    return response;
                }

                var customerHasRealEstates = await _realEstateRepository.GetRealEstateByCustomerIdAsync(customerId);

                if(customerHasRealEstates != null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Customer ID {customerId} belongs to a real estate and cannot be deleted.");
                    return response;
                }

                var result = await _customerRepository.DeleteCustomerByIdAsync(customerId);

                if (result)
                {
                    response.IsSuccess = true;
                    response.Result = existingCustomer;
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete customer ID: {customerId}.");
                response.AdditionalInformation.Add(ex.Message);
            }          

            return response;
        }
    }
}