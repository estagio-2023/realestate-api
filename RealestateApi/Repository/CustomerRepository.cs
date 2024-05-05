using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service;

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
        public async Task<ServiceResult<List<CustomerModel>>> GetAllCustomersAsync()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            var result = new ServiceResult<List<CustomerModel>>();

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

                result.IsSuccess = true;
                result.Result = customers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.IsSuccess = false;
                result.AdditionalInformation.Add(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 
        /// Adds a Customer to the Database
        /// 
        /// </summary>
        /// <param name="customerData"> Customer Data to be created </param>
        /// <returns> CustomerModel </returns>
        public async Task<ServiceResult<CustomerModel>> AddCustomerAsync(CustomerRequestDto customerData) 
        {
            CustomerModel response = new();
            var serviceResult = new ServiceResult<CustomerModel>();

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

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        /// <summary>
        /// 
        /// Gets a Customer by Id from the Database
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        public async Task<ServiceResult<CustomerModel>> GetCustomerByIdAsync(int customerId)
        {
            CustomerModel response = new();
            var result = new ServiceResult<CustomerModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var customerQuery = new NpgsqlCommand("SELECT * FROM customer WHERE id = @customerId;", conn);
                customerQuery.Parameters.AddWithValue("@customerId", customerId);
                using var customerReader = await customerQuery.ExecuteReaderAsync();

                if(customerReader.HasRows)
                {
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
                } else
                {
                    result.AdditionalInformation.Add($"Reference Data ID {customerId} doesn't exist");
                    return result;
                }

                result.IsSuccess = true;
                result.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.IsSuccess = false;
                result.AdditionalInformation.Add(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 
        /// Deletes a Customer by Id from the Database
        /// 
        /// </summary>
        /// <param name="customerId"> Id to get Customer </param>
        /// <returns> CustomerModel </returns>
        public async Task<ServiceResult<CustomerModel>> DeleteCustomerByIdAsync(int customerId)
        {
            var serviceResult = new ServiceResult<CustomerModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var delete = new NpgsqlCommand("DELETE FROM customer WHERE id = @customerId", conn);
                delete.Parameters.AddWithValue("@customerId", customerId);

                var response = await GetCustomerByIdAsync(customerId);
                var result = await delete.ExecuteScalarAsync();

                serviceResult.IsSuccess = true;
                serviceResult.Result = response.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }
    }
}