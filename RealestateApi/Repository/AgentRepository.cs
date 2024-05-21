using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;

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
        public async Task<List<AgentModel>> GetAllAgentsAsync()
        {
            List<AgentModel> response = new();
            
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
                    response.Add(agentModel);
                }
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gets a Agent by Id from the Database
        /// 
        /// </summary>
        /// <param name="agentId"> Id to get Agent </param>
        /// <returns> AgentModel </returns>
        public async Task<AgentModel?> GetAgentByIdAsync(int agentId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var agentQuery = new NpgsqlCommand("SELECT * FROM agent WHERE id = @agentId;", conn);
            agentQuery.Parameters.AddWithValue("@agentId", agentId);

            using var agentReader = await agentQuery.ExecuteReaderAsync();

            if (agentReader.HasRows)
            {
                AgentModel response = new();

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

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Adds a Agent to the Database
        /// 
        /// </summary>
        /// <param name="agentData"> Agent Data to be created </param>
        /// <returns> AgentModel </returns>
        public async Task<AgentModel?> AddAgentAsync(AgentRequestDto agentData) 
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("INSERT INTO agent (name, phone_number, email) Values (@agentName, @agentPhoneNumber, @agentEmail) returning id", conn);
            query.Parameters.Add(new NpgsqlParameter("@agentName", NpgsqlDbType.Text) { Value = agentData.Name });
            query.Parameters.Add(new NpgsqlParameter("@agentPhoneNumber", NpgsqlDbType.Text) { Value = agentData.Phone_Number });
            query.Parameters.Add(new NpgsqlParameter("@agentEmail", NpgsqlDbType.Text) { Value = agentData.Email });
            
            var result = await query.ExecuteScalarAsync();

            if(result != null)
            {
                var response = new AgentModel
                {
                    Id = (int)result,
                    Name = agentData.Name,
                    PhoneNumber = agentData.Phone_Number,
                    Email = agentData.Email,
                };

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Deletes a Agent by Id from the Database
        /// 
        /// </summary>
        /// <param name="agentId"> Id to delete Agent </param>
        /// <returns> AgentModel </returns>
        public async Task<bool> DeleteAgentByIdAsync(int agentId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var delete = new NpgsqlCommand("DELETE FROM agent WHERE id = @AgentId", conn);
            delete.Parameters.AddWithValue("@AgentId", agentId);

            var affectedRows = await delete.ExecuteNonQueryAsync();

            return affectedRows > 0;
        }
    }
}