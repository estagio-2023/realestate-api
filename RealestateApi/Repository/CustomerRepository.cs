﻿using Npgsql;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;

namespace RealEstateApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public CustomerRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<List<ClientModel>> GetAllCustomersAsync()
        {
            List<ClientModel> customers = new List<ClientModel>();
            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var customerQuery = new NpgsqlCommand("SELECT * FROM client;", conn);
                using var customerReader = await customerQuery.ExecuteReaderAsync();

                while (await customerReader.ReadAsync())
                {
                    var customerModel = new ClientModel
                    {
                        Id = (int)customerReader["id"],
                        Name = (string)customerReader["name"],
                        Email = (string)customerReader["email"],
                        Password = (string)customerReader["password"],
                    };
                    customers.Add(customerModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }
    }
}
