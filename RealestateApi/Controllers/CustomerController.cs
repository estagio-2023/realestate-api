using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Enums;
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
        /// <returns> List<CustomerResponseDto> </returns>
        [HttpGet(Name = "GetAllCustomers")]
        public async Task<ActionResult<List<CustomerResponseDto>>> GetAllCustomersAsync()
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
        /// <returns> CustomerResponseDto </returns>
        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult<CustomerResponseDto>> AddCustomerAsync(CustomerRequestDto customerData)
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
        /// <returns> CustomerResponseDto </returns>
        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public async Task<ActionResult<CustomerResponseDto>> GetCustomerByIdAsync(int customerId)
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
        /// <returns> CustomerResponseDto </returns>
        [HttpDelete("{customerId}", Name = "DeleteCustomerById")]
        public async Task<ActionResult<CustomerResponseDto>> DeleteCustomerByIdAsync(int customerId)
        {
            var response = await _customerService.DeleteCustomerByIdAsync(customerId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
    }
}