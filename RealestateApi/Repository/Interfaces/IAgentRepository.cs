using RealEstateApi.Model;
using RealEstateApi.Service;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IAgentRepository
    {
        /// <summary>
        /// 
        /// Gather a List of all 
        /// 
        /// </summary>
        /// <returns> List<AgentModel> </returns>
        Task<ServiceResult<List<AgentModel>>> GetAllAgentsAsync();
    }
}