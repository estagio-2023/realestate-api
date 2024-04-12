using Npgsql;
using RealEstateApi.Dto.Response;
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

        public async Task<CustomerResponseDto> GetAllCustomersAsync()
        {
            CustomerResponseDto customerData = new CustomerResponseDto(); 
            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var customerQuery = new NpgsqlCommand("SELECT * FROM client;", conn);
                using var customerReader = await customerQuery.ExecuteReaderAsync();

                while (await customerReader.ReadAsync())
                {
                    var customerModel = new ClientModel
                    {   
                        Id = customerReader.GetInt32(customerReader.GetOrdinal("id")),
                        Name = customerReader.GetString(customerReader.GetOrdinal("name")),
                        Email = customerReader.GetString(customerReader.GetOrdinal("email")),
                        Password = customerReader.GetString(customerReader.GetOrdinal("password")),
                    };
                    customerData.Customers.Add(customerModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customerData;
        }
    }
}
