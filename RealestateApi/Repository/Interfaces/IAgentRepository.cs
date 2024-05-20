using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Service;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IAgentRepository
    {
        /// <summary>
        /// 
        /// Gather a List of all Agents
        /// 
        /// </summary>
        /// <returns> List<AgentModel> </returns>
        Task<List<AgentModel>> GetAllAgentsAsync();

        /// <summary>
        /// 
        /// Gets an Agent by Id
        /// 
        /// </summary>
        /// <returns> AgentModel </returns>
        Task<AgentModel?> GetAgentByIdAsync(int agentId);

        /// <summary>
        /// 
        /// Save a Agent
        /// 
        /// </summary>
        /// <param name="agentData"> Agent Data to be Saved </param>
        /// <returns> AgentModel </returns>
        Task<AgentModel?> AddAgentAsync(AgentRequestDto agentData);

        /// <summary>
        /// 
        /// Deletes a Agent by Id
        /// 
        /// </summary>
        /// <param name="agentId"> Id to delete Agent </param>
        /// <returns> AgentModel </returns>
        Task<bool> DeleteAgentByIdAsync(int agentId);

        /// <summary>
        /// 
        /// Updates a Agent
        /// 
        /// </summary>
        /// <param name="agentId"> Id to update Agent </param>
        /// <param name="newAgentData"> Agent Data to be Updated </param>
        /// <returns> AgentModel </returns>
        Task<AgentModel?> PutAgenteByIdAsync(int agentId, AgentRequestDto newAgentData);
    }
}