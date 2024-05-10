using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
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

        /// <summary>
        /// 
        ///  Gets all the Customers from the Database
        /// 
        /// </summary>
        /// <returns> List<CustomerModel> </returns>
        public async Task<List<CustomerModel>> GetAllCustomersAsync()
        {
            List<CustomerModel> response = new();

            using var conn = await _dataSource.OpenConnectionAsync();

            using var customerQuery = new NpgsqlCommand("SELECT * FROM customer;", conn);
            using var customerReader = await customerQuery.ExecuteReaderAsync();
            
            if (customerReader.HasRows) 
            {
                while (await customerReader.ReadAsync())
                {
                    var customerModel = new CustomerModel
                    {
                        Id = (int)customerReader["id"],
                        Name = (string)customerReader["name"],
                        Email = (string)customerReader["email"],
                        Password = (string)customerReader["password"],
                    };
                    response.Add(customerModel);
                }
            }                
            
            return response;
        }       

        /// <summary>
        /// 
        /// Gets a Customer by Id from the Database
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        public async Task<CustomerModel?> GetCustomerByIdAsync(int customerId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var customerQuery = new NpgsqlCommand("SELECT * FROM customer WHERE id = @customerId;", conn);
            customerQuery.Parameters.AddWithValue("@customerId", customerId);
                
            using var customerReader = await customerQuery.ExecuteReaderAsync();

            if(customerReader.HasRows)
            {
                CustomerModel response = new();

                while (await customerReader.ReadAsync())
                {
                    response = new CustomerModel
                    {
                        Id = (int)customerReader["id"],
                        Name = (string)customerReader["name"],
                        Email = (string)customerReader["email"],
                        Password = (string)customerReader["password"],
                    };
                }

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Adds a Customer to the Database
        /// 
        /// </summary>
        /// <param name="customerData"> Customer Data to be created </param>
        /// <returns> CustomerModel </returns>
        public async Task<CustomerModel?> AddCustomerAsync(CustomerRequestDto customerData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand(@"INSERT INTO customer (name, email, password) VALUES (@customerName, @customerEmail, @customerPassword) returning id", conn);
            query.Parameters.Add(new NpgsqlParameter("@customerName", NpgsqlDbType.Text) { Value = customerData.Name });
            query.Parameters.Add(new NpgsqlParameter("@customerEmail", NpgsqlDbType.Text) { Value = customerData.Email });
            query.Parameters.Add(new NpgsqlParameter("@customerPassword", NpgsqlDbType.Text) { Value = customerData.Password });

            var result = await query.ExecuteScalarAsync();

            if (result != null)
            {                
                var response = new CustomerModel
                {
                    Id = (int)result,
                    Name = customerData.Name,
                    Email = customerData.Email,
                    Password = customerData.Password
                };

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Deletes a Customer by Id from the Database
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        public async Task<bool> DeleteCustomerByIdAsync(int customerId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var delete = new NpgsqlCommand("DELETE FROM customer WHERE id = @customerId", conn);
            delete.Parameters.AddWithValue("@customerId", customerId);                

            var affectedRows = await delete.ExecuteNonQueryAsync();

            return affectedRows > 0;
        }
    }
}