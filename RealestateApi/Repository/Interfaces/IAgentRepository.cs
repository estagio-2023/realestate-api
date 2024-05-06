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
        Task<ServiceResult<List<AgentModel>>> GetAllAgentsAsync();

        /// <summary>
        /// 
        /// Gets an Agent by Id
        /// 
        /// </summary>
        /// <returns> AgentModel </returns>
        Task<ServiceResult<AgentModel>> GetAgentByIdAsync(int agentId);
        Task<ServiceResult<AgentModel>> DeleteAgentById(int agentId);
    }
}