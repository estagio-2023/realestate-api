using RealEstateApi.Model;
using RealEstateApi.Repository;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        /// <summary>
        /// 
        /// Gather a List of all Agents
        /// 
        /// </summary>
        /// <returns> List<AgentModel> </returns>
        public async Task<ServiceResult<List<AgentModel>>> GetAllAgentsAsync()
        {
            return await _agentRepository.GetAllAgentsAsync();
        }

        /// <summary>
        /// 
        /// Gets a Agent by Id
        /// 
        /// </summary>
        /// <param name="agentId"> Id to get Agent </param>
        /// <returns> AgentModel </returns>
        public async Task<ServiceResult<AgentModel>> GetAgentByIdAsync(int agentId)
        {
            return await _agentRepository.GetAgentByIdAsync(agentId);
        }
    }
}