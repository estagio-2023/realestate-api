using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service;
using System.Xml.Linq;

namespace RealEstateApi.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public AgentRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        /// <summary>
        /// 
        ///  Gets all the Agents from the Database
        /// 
        /// </summary>
        /// <returns> List<AgentModel> </returns>
        public async Task<ServiceResult<List<AgentModel>>> GetAllAgentsAsync()
        {
            List<AgentModel> agents = new List<AgentModel>();
            var result = new ServiceResult<List<AgentModel>>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var agentQuery = new NpgsqlCommand("SELECT * FROM agent;", conn);
                using var agentReader = await agentQuery.ExecuteReaderAsync();

                while (await agentReader.ReadAsync())
                {
                    var agentModel = new AgentModel
                    {
                        Id = (int)agentReader["id"],
                        Name = (string)agentReader["name"],
                        PhoneNumber = (string)agentReader["phone_number"],
                        Email = (string)agentReader["email"],
                    };
                    agents.Add(agentModel);
                }

                result.IsSuccess = true;
                result.Result = agents;
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
        /// Gets a Agent by Id from the Database
        /// 
        /// </summary>
        /// <param name="agentId"> Id to get Agent </param>
        /// <returns> AgentModel </returns>
        public async Task<ServiceResult<AgentModel>> GetAgentByIdAsync(int agentId)
        {
            AgentModel response = new();
            var result = new ServiceResult<AgentModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var agentQuery = new NpgsqlCommand("SELECT * FROM agent WHERE id = @agentId;", conn);
                agentQuery.Parameters.AddWithValue("@agentId", agentId);
                using var agentReader = await agentQuery.ExecuteReaderAsync();

                if (agentReader.HasRows)
                {
                    while (await agentReader.ReadAsync())
                    {
                        response = new AgentModel
                        {
                            Id = (int)agentReader["id"],
                            Name = (string)agentReader["name"],
                            PhoneNumber = (string)agentReader["phone_number"],
                            Email = (string)agentReader["email"],
                        };
                    }
                }
                else
                {
                    result.AdditionalInformation.Add($"Agent ID {agentId} doesn't exist");
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
        /// Adds a Agent to the Database
        /// 
        /// </summary>
        /// <param name="agentData"> Agent Data to be created </param>
        /// <returns> AgentModel </returns>
        public async Task<ServiceResult<AgentModel>> AddAgentAsync(AgentRequestDto agentData) 
        { 
            AgentModel response = new();
            var serviceResult = new ServiceResult<AgentModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var query = new NpgsqlCommand("INSERT INTO agent (name, phone_number, email) Values (@agentName, @agentPhoneNumber, @agentEmail) returning id", conn);

                query.Parameters.Add(new NpgsqlParameter("@agentName", NpgsqlDbType.Text) { Value = agentData.Name });
                query.Parameters.Add(new NpgsqlParameter("@agentPhoneNumber", NpgsqlDbType.Text) { Value = agentData.Phone_Number });
                query.Parameters.Add(new NpgsqlParameter("@agentEmail", NpgsqlDbType.Text) { Value = agentData.Email });
                var result = await query.ExecuteScalarAsync();

                response = new AgentModel
                {
                    Id = (int)result,
                    Name = agentData.Name,
                    PhoneNumber = agentData.Phone_Number,
                    Email = agentData.Email,
                };

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;

            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }
    }
}