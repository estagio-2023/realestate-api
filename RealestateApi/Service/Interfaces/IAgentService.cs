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
    }
}