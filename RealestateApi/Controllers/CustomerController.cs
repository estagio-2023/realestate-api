using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Service;
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

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<ActionResult<List<CustomerModel>>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                return customers.IsSuccess ? Ok(customers.Result) : Problem(customers.ProblemType, customers.AdditionalInformation.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customers.");
                throw;
            }
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult<CustomerModel>> AddCustomerAsync(CustomerRequestDto customerData)
        {
            var addCustomer = await _customerService.AddCustomerAsync(customerData);
            return addCustomer.IsSuccess ? Ok(addCustomer.Result) : Problem(addCustomer.ProblemType, addCustomer.AdditionalInformation.ToString());
        }

        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public async Task<ActionResult<CustomerModel>> GetCustomerByIdAsync(int customerId)
        {
            var getCustomerById = await _customerService.GetCustomerByIdAsync(customerId);
            return getCustomerById.IsSuccess ? Ok(getCustomerById.Result) : Problem(getCustomerById.ProblemType, getCustomerById.AdditionalInformation.ToString());
        }
    }
}