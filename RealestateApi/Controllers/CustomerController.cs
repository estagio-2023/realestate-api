using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<ClientModel>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customers.");
                throw;
            }
        }
        [HttpPost(Name = "AddCustomer")]
        public async Task<AddCustomDto> AddCustomerAsync(CustomDto customerData)
        {
            return await _customerService.AddCustomersAsync(customerData);
        }
    }
}