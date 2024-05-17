using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Enums;
using RealEstateApi.Helpers;
using RealEstateApi.Model;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        /// <summary>
        /// 
        /// Https Get Method to gather a List of all Customers
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/Customer
        /// 
        /// <returns> List<CustomerModel> </returns>
        [HttpGet(Name = "GetAllCustomers")]
        public async Task<ActionResult<List<CustomerModel>>> GetAllCustomersAsync()
        {
            var response = await _customerService.GetAllCustomersAsync();
                
            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation, (int)HttpCodesEnum.BadRequest));            
        }

        /// <summary>
        /// 
        /// Https Post Method to create a Customer
        /// 
        /// </summary>
        /// <param name="customerData"> Customer Data to be created </param>
        /// 
        /// Sample Request:
        /// 
        ///     POST /api/Customer
        ///     
        /// <returns> CustomerModel </returns>
        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult<CustomerModel>> AddCustomerAsync(CustomerRequestDto customerData)
        {
            var response = await _customerService.AddCustomerAsync(customerData);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation, (int)HttpCodesEnum.BadRequest));
        }

        /// <summary>
        /// 
        /// Https Get Method to get a Customer by Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// 
        ///  Sample Request:
        /// 
        ///     GET api/Customer/{customerId}
        ///     
        /// <returns> CustomerModel </returns>
        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public async Task<ActionResult<CustomerModel>> GetCustomerByIdAsync(int customerId)
        {
            var response = await _customerService.GetCustomerByIdAsync(customerId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https Delete Method to delete a Customer by Id
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// 
        ///  Sample Request:
        /// 
        ///     DELETE api/Customer/{customerId}
        ///     
        /// <returns> CustomerModel </returns>
        [HttpDelete("{customerId}", Name = "DeleteCustomerById")]
        public async Task<ActionResult<CustomerModel>> DeleteCustomerByIdAsync(int customerId)
        {
            var response = await _customerService.DeleteCustomerByIdAsync(customerId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
    }
}