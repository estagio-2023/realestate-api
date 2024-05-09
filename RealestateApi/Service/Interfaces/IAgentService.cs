using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IAgentService
    {
        /// <summary>
        /// 
        /// Gathers a List of all Agents
        /// 
        /// </summary>
        /// <returns> List<AgentModel> </returns>
        Task<ServiceResult<List<AgentModel>>> GetAllAgentsAsync();

        /// <summary>
        /// 
        /// Gets an Agent by Id
        /// 
        /// </summary>
        /// <param name="agentId"> Id to get an Agent </param>
        /// <returns> AgentModel </returns>
        Task<ServiceResult<AgentModel>> GetAgentByIdAsync(int agentId);
    }
}