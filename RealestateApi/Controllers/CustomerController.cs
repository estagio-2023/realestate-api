using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Service;
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
        private readonly IValidator<CustomerRequestDto> _customerRequestValidatorDto;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService, IValidator<CustomerRequestDto> customerRequestValidatorDto)
        {
            _logger = logger;
            _customerService = customerService;
            _customerRequestValidatorDto = customerRequestValidatorDto;
        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<List<CustomerModel>> GetAllCustomersAsync()
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
        public async Task<CustomerModel> AddCustomerAsync(CustomerRequestDto customerData)
        {
            var validationResult = _customerRequestValidatorDto.Validate(customerData);

            if (!validationResult.IsValid)
            {
                return new CustomerModel();
            }

            return await _customerService.AddCustomerAsync(customerData);
        }

        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public async Task<CustomerModel> GetCustomerByIdAsync(int customerId)
        {
            return await _customerService.GetCustomerByIdAsync(customerId);
        }
    }
}