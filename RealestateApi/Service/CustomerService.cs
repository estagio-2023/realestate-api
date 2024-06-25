using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Service.Interfaces;
using RealEstateApiLibraryEF.DataAccess;
using RealEstateApiLibraryEF.Entity;

namespace RealEstateApi.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly RealEstateContext _DbContext;
        private readonly IMapper _mapper;

        public CustomerService(RealEstateContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// Gather a List of all Customers
        /// 
        /// </summary>
        /// <returns> List<CustomerModel> </returns>
        public async Task<ServiceResult<List<CustomerResponseDto>>> GetAllCustomersAsync()
        {
            ServiceResult<List<CustomerResponseDto>> response = new();

            try
            {
                var customers = await _DbContext.Customers.ToListAsync();
                var result = _mapper.Map<List<CustomerResponseDto>>(customers);

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
        public async Task<ServiceResult<CustomerResponseDto>> GetCustomerByIdAsync(int customerId)
        {
            ServiceResult<CustomerResponseDto> response = new();

            try
            {
                var customer = await _DbContext.Customers.FindAsync(customerId);
                var result = _mapper.Map<CustomerResponseDto>(customer);

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
        public async Task<ServiceResult<CustomerResponseDto>> AddCustomerAsync(CustomerRequestDto customerData)
        {
            ServiceResult<CustomerResponseDto> response = new();

            var transaction = _DbContext.Database.BeginTransaction();
            try
            {
                var toEntity = _mapper.Map<Customer>(customerData);
                var customer = await _DbContext.Customers.AddAsync(toEntity);
                await _DbContext.SaveChangesAsync();

                var result = _mapper.Map<CustomerResponseDto>(customer.Entity);

                if(result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }

                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
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
        public async Task<ServiceResult<CustomerResponseDto>> DeleteCustomerByIdAsync(int customerId)
        {
            ServiceResult<CustomerResponseDto> response = new();

            var transaction = _DbContext.Database.BeginTransaction();
            try
            {
                var existingCustomer = await _DbContext.Customers.FindAsync(customerId);

                if (existingCustomer == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Customer ID {customerId} was not found");
                    return response;
                }

                var customerHasRealEstates = await _DbContext.RealEstates.AnyAsync(res => res.CustomerId == customerId);

                if (customerHasRealEstates)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Customer ID {customerId} is associated with real estates and cannot be deleted.");
                    return response;
                }

                _DbContext.Customers.Remove(existingCustomer);
                await _DbContext.SaveChangesAsync();

                var result = _mapper.Map<CustomerResponseDto>(existingCustomer);

                response.IsSuccess = true;
                response.Result = result;

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete customer ID: {customerId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }
    }
}