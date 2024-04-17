﻿using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
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

        public async Task<List<ClientModel>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }
        public async Task<ClientModel> AddCustomerAsync(CustomerRequestDto customerData)
        {
            ClientModel response = new();

            if (customerData != null) { 
                response = await _customerRepository.AddCustomerAsync(customerData);
            }
            return response;
        }
    }
}
