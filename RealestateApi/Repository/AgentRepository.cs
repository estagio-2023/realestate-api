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
    }
}