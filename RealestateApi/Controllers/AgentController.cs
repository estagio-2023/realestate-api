using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Model;
using RealEstateApi.Service;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly ILogger<AgentController> _logger;
        private readonly IAgentService _agentService;

        public AgentController(ILogger<AgentController> logger, IAgentService agentService)
        {
            _logger = logger;
            _agentService = agentService;
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
        /// <returns> List<AgentModel> </returns>
        [HttpGet(Name = "GetAllAgents")]
        public async Task<ActionResult<List<AgentModel>>> GetAllAgentsAsync()
        {
            try
            {
                var agents = await _agentService.GetAllAgentsAsync();
                return agents.IsSuccess ? Ok(agents.Result) : Problem(agents.ProblemType, agents.AdditionalInformation.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving agents.");
                throw;
            }
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
        /// <returns> AgentModel </returns>
        [HttpGet("{agentId}", Name = "GetAgentById")]
        public async Task<ActionResult<AgentModel>> GetAgentByIdAsync(int agentId)
        {
            try
            {
                var agentbyId = await _agentService.GetAgentByIdAsync(agentId);
                return agentbyId.IsSuccess ? Ok(agentbyId.Result) : Problem(agentbyId.ProblemType, agentbyId.AdditionalInformation.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving agent.");
                throw;
            }
        }

        [HttpDelete("{agentId}", Name = "DeleteAgentById")]
        public async Task<ActionResult<AgentModel>> DeleteAgentByIdAsync(int agentId)
        {
            var deleteAgent = await _agentService.DeleteAgentByIdAsync(agentId);
            return deleteAgent.IsSuccess ? Ok(deleteAgent.Result) : Problem(deleteAgent.ProblemType, string.Join(",", deleteAgent.AdditionalInformation));
        }
    }
}