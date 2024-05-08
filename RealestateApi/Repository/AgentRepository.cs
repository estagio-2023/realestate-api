using Npgsql;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service;

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

                if (agentReader.HasRows) 
                {
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
                }
                else
                {
                    result.AdditionalInformation.Add($"No data to retrieve");
                    return result;
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
    }
}