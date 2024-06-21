using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Service.Interfaces;
using RealEstateApiLibraryEF.DataAccess;
using RealEstateApiLibraryEF.Entity;

namespace RealEstateApi.Service
{
    public class AgentService : IAgentService
    {
        private readonly RealEstateContext _DbContext;
        private readonly IMapper _mapper;

        public AgentService(RealEstateContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// Gather a List of all Agents
        /// 
        /// </summary>
        /// <returns> List<AgentModel> </returns>
        public async Task<ServiceResult<List<AgentResponseDto>>> GetAllAgentsAsync()
        {
            ServiceResult<List<AgentResponseDto>> response = new();

            try
            {
                var agents = await _DbContext.Agents.ToListAsync();
                var result = _mapper.Map<List<AgentResponseDto>>(agents);

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
        public async Task<ServiceResult<AgentResponseDto>> GetAgentByIdAsync(int agentId)
        {
            ServiceResult<AgentResponseDto> response = new();

            try
            {
                var agent = await _DbContext.Agents.FindAsync(agentId);
                var result = _mapper.Map<AgentResponseDto>(agent);

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
        public async Task<ServiceResult<AgentResponseDto>> AddAgentAsync(AgentRequestDto agentData)
        {
            ServiceResult<AgentResponseDto> response = new();  

            try
            {
                var toEntity = _mapper.Map<Agent>(agentData);

                var agent = await _DbContext.Agents.AddAsync(toEntity);
                await _DbContext.SaveChangesAsync();

                var result = _mapper.Map<AgentResponseDto>(agent.Entity);

                if (toEntity != null)
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
        public async Task<ServiceResult<AgentResponseDto>> DeleteAgentByIdAsync(int agentId)
        {
            ServiceResult<AgentResponseDto> response = new();

            try
            {
                var existingAgent = await _DbContext.Agents.FindAsync(agentId);

                if (existingAgent == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Agent ID {agentId} was not found");
                    return response;
                }

                _DbContext.Agents.Remove(existingAgent);
                await _DbContext.SaveChangesAsync();

                var result = _mapper.Map<AgentResponseDto>(existingAgent);

                response.IsSuccess = true;
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete agent ID: {agentId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Updates an Agent by Id
        /// 
        /// </summary>
        /// <param name="agentId"> Id to update an Agent </param>
        /// <param name="newAgentData"> Data to be updated </param>
        /// <returns> AgentModel </returns>
        public async Task<ServiceResult<AgentResponseDto>> PutAgentByIdAsync(int agentId, AgentRequestDto newAgentData)
        {
            ServiceResult<AgentResponseDto> response = new();

            try
            {
                var existingAgent = await _DbContext.Agents.FindAsync(agentId);

                if (existingAgent == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Agent ID {agentId} was not found");
                    return response;
                }

                _mapper.Map(newAgentData, existingAgent);
                await _DbContext.SaveChangesAsync();

                var updatedAgentDto = _mapper.Map<AgentResponseDto>(existingAgent);

                response.IsSuccess = true;
                response.Result = updatedAgentDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to update agent, ID: {agentId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }
    }
}