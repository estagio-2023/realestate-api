using RealEstateApi.Dto.Response;
using RealEstateApi.Dto.Request;

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
        Task<ServiceResult<List<AgentResponseDto?>>> GetAllAgentsAsync();

        /// <summary>
        /// 
        /// Gets an Agent by Id
        /// 
        /// </summary>
        /// <param name="agentId"> Id to get an Agent </param>
        /// <returns> AgentModel </returns>
        Task<ServiceResult<AgentResponseDto?>> GetAgentByIdAsync(int agentId);

        
        /// <summary>
        /// 
        /// Save a Agent
        /// 
        /// </summary>
        /// <param name="agentData"> Agent Data to be Saved </param>
        /// <returns> AgentModel </returns>
        Task<ServiceResult<AgentResponseDto>> AddAgentAsync(AgentRequestDto agentData);

        
        Task<ServiceResult<AgentResponseDto>> DeleteAgentByIdAsync(int agentId);
        /*
        /// <summary>
        /// 
        /// Updates an Agent
        /// 
        /// </summary>
        /// <param name="agentId"> Id to update an Agent </param>
        /// <param name="newAgentData"> Agent Data to be Updated </param>
        /// <returns> AgentModel </returns>
        Task<ServiceResult<AgentModel>> PutAgentByIdAsync(int agentId, AgentRequestDto newAgentData);*/
    }
}