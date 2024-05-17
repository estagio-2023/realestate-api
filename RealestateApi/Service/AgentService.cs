using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IRealEstateRepository _realEstateRepository;

        public AgentService(IAgentRepository agentRepository, IRealEstateRepository realEstateRepository)
        {
            _agentRepository = agentRepository;
            _realEstateRepository = realEstateRepository;
        }

        /// <summary>
        /// 
        /// Gather a List of all Agents
        /// 
        /// </summary>
        /// <returns> List<AgentModel> </returns>
        public async Task<ServiceResult<List<AgentModel>>> GetAllAgentsAsync()
        {
            ServiceResult<List<AgentModel>> response = new();

            try
            {
                var result = await _agentRepository.GetAllAgentsAsync();

                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add("There was an error while trying to retrieve all agents.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gets a Agent by Id
        /// 
        /// </summary>
        /// <param name="agentId"> Id to get Agent </param>
        /// <returns> AgentModel </returns>
        public async Task<ServiceResult<AgentModel?>> GetAgentByIdAsync(int agentId)
        {
            ServiceResult<AgentModel?> response = new();

            try
            {
                var result = await _agentRepository.GetAgentByIdAsync(agentId);

                if (result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Agent ID {agentId} was not found.");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to get agent ID: {agentId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Creates a Agent
        /// 
        /// </summary>
        /// <param name="agentData"> Data to be saved </param>
        /// <returns> AgentModel </returns>
        public async Task<ServiceResult<AgentModel>> AddAgentAsync(AgentRequestDto agentData) 
        {
            ServiceResult<AgentModel> response = new();

            try
            {
                var result = await _agentRepository.AddAgentAsync(agentData);

                if (result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to add Agent {agentData.Name}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Deletes a Agent by Id
        /// 
        /// </summary>
        /// <param name="agentId"> Id to delete Agent </param>
        /// <returns> AgentModel </returns>
        public async Task<ServiceResult<AgentModel>> DeleteAgentByIdAsync(int agentId)
        {
            ServiceResult<AgentModel> response = new();

            try
            {
                var existingAgent = await _agentRepository.GetAgentByIdAsync(agentId);

                if (existingAgent == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Agent ID {agentId} was not found");
                    return response;
                }

                var agentHasRealEstates = await _realEstateRepository.GetRealEstateByAgentIdAsync(agentId);

                if (agentHasRealEstates != null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Agent ID {agentId} belongs to a real estate and cannot be deleted.");
                    return response;
                }

                var result = await _agentRepository.DeleteAgentByIdAsync(agentId);

                if (result)
                {
                    response.IsSuccess = true;
                    response.Result = existingAgent;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete agent ID: {agentId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

    }
}