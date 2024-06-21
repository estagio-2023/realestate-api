using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Enums;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly ILogger<AgentController> _logger;
        private readonly IAgentService _agentService;
        private readonly IValidator<AgentRequestDto> _agentRequestValidatorDto;

        public AgentController(ILogger<AgentController> logger, IAgentService agentService, IValidator<AgentRequestDto> agentRequestValidatorDto)
        {
            _logger = logger;
            _agentService = agentService;
            _agentRequestValidatorDto = agentRequestValidatorDto;
        }

        /// <summary>
        /// 
        /// Https Get Method to gather a List of all Agents
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/Agent
        /// 
        /// <returns> List<AgentResponseDto> </returns>
        [HttpGet(Name = "GetAllAgents")]
        public async Task<ActionResult<List<AgentResponseDto>>> GetAllAgentsAsync()
        {
            var response = await _agentService.GetAllAgentsAsync();
            
            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https Get Method to an Agent by Id
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/Agent/{agentId}
        /// 
        /// <returns> AgentResponseDto </returns>
        [HttpGet("{agentId}", Name = "GetAgentById")]
        public async Task<ActionResult<AgentResponseDto>> GetAgentByIdAsync(int agentId)
        {            
            var response = await _agentService.GetAgentByIdAsync(agentId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https Post Method to create an Agent
        /// 
        /// </summary>
        /// <param name="agentData"> Agent Data to be created </param>
        /// 
        /// Sample Request:
        /// 
        ///     POST /api/Agent
        ///     
        /// <returns> AgentResponseDto </returns>
        [HttpPost(Name = "AddAgent")]
        public async Task<ActionResult<AgentResponseDto>> AddAgentAsync(AgentRequestDto agentData)
        {
            var response = await _agentService.AddAgentAsync(agentData);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https Delete Method to delete a Agent by Id
        /// 
        /// </summary>
        /// <param name="agentId"> Id to get Agent </param>
        /// 
        ///  Sample Request:
        /// 
        ///     DELETE api/Agent/{agentId}
        ///     
        /// <returns> AgentResponseDto </returns>
        [HttpDelete("{agentId}", Name = "DeleteAgentById")]
        public async Task<ActionResult<AgentResponseDto>> DeleteAgentByIdAsync(int agentId)
        {
            var response = await _agentService.DeleteAgentByIdAsync(agentId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https Put Method to updated an Agent
        /// 
        /// </summary>
        /// <param name="agentId"> Id to update an Agent </param>
        /// <param name="newAgentData"> Agent Data to be updated </param>
        /// <returns> AgentModel </returns>
        [HttpPut("{agentId}", Name = "PutAgentById")]
        public async Task<ActionResult<AgentResponseDto>> PutAgentByIdAsync(int agentId, AgentRequestDto newAgentData)
        {
            var response = await _agentService.PutAgentByIdAsync(agentId, newAgentData);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
    }
}