using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
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

        public async Task<List<CustomerModel>> GetAllCustomersAsync()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var customerQuery = new NpgsqlCommand("SELECT * FROM customer;", conn);
                using var customerReader = await customerQuery.ExecuteReaderAsync();

                while (await customerReader.ReadAsync())
                {
                    var customerModel = new CustomerModel
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

        public async Task<CustomerModel> AddCustomerAsync(CustomerRequestDto customerData) 
        {
            CustomerModel response = new();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var query = new NpgsqlCommand(@"INSERT INTO customer (name, email, password) VALUES (@customerName, @customerEmail, @customerPassword) returning id", conn);

                query.Parameters.Add(new NpgsqlParameter("@customerName", NpgsqlDbType.Text) { Value = customerData.Name });
                query.Parameters.Add(new NpgsqlParameter("@customerEmail", NpgsqlDbType.Text) { Value = customerData.Email });
                query.Parameters.Add(new NpgsqlParameter("@customerPassword", NpgsqlDbType.Text) { Value = customerData.Password });
                var result = await query.ExecuteScalarAsync();

                response = new CustomerModel
                {
                    Id = (int)result,
                    Name = customerData.Name,
                    Email = customerData.Email,
                    Password = customerData.Password
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return response;
        }

        public async Task<CustomerModel> GetCustomerByIdAsync(int customerId)
        {
            CustomerModel response = new();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var customerQuery = new NpgsqlCommand("SELECT * FROM customer WHERE id = @customerId;", conn);
                customerQuery.Parameters.AddWithValue("@customerId", customerId);
                using var customerReader = await customerQuery.ExecuteReaderAsync();
               
                while(await customerReader.ReadAsync())
                {
                    response = new CustomerModel
                    {
                        Id = (int)customerReader["id"],
                        Name = (string)customerReader["name"],
                        Email = (string)customerReader["email"],
                        Password = (string)customerReader["password"],
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return response;
        }
    }
}