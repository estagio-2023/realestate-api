using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Service;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealEstateController : ControllerBase
    {
        private readonly ILogger<RealEstateController> _logger;
        private readonly IRealEstateService _realEstateService;

        public RealEstateController(ILogger<RealEstateController> logger, IRealEstateService realEstateService)
        {
            _logger = logger;
            _realEstateService = realEstateService;
        }

        /// <summary>
        /// 
        /// Https Get Method to gather a List of all Real Estates
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/RealEstate
        /// 
        /// <returns> List<RealEstateRequestDto </returns>
        [HttpGet(Name = "GetAllRealEstate")]
        public async Task<ActionResult<List<RealEstateRequestDto>>> GetAllRealEstate()
        {
            var getAllRealEstate = await _realEstateService.GetAllRealEstateAsync();
            return getAllRealEstate.IsSuccess ? Ok(getAllRealEstate.Result) : Problem(getAllRealEstate.ProblemType, getAllRealEstate.AdditionalInformation.ToString());
        }

        /// <summary>
        /// 
        /// Https Post Method to create a Real Estate
        /// 
        /// </summary>
        /// <param name="realEstateDto"> Real Estate Data to be created </param>
        /// 
        /// Sample Request:
        /// 
        ///     POST /api/RealEstate
        /// 
        /// <returns> RealEstateModel </returns>
        [HttpPost(Name = "AddRealEstate")]
        public async Task<ActionResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            var addRealEstate = await _realEstateService.AddRealEstateAsync(realEstateDto);
            return addRealEstate.IsSuccess ? Ok(addRealEstate.Result) : Problem(addRealEstate.ProblemType, addRealEstate.AdditionalInformation.ToString());
        }

        /// <summary>
        /// 
        /// Https Get Method to get a Real Estate by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get Real Estate </param>
        /// 
        /// Sample Request:
        /// 
        ///     GET api/RealEstate/{realEstateId}
        /// 
        /// <returns> RealEstateModel </returns>
        [HttpGet("{realEstateId}", Name = "GetRealEstateById")]
        public async Task<ActionResult<RealEstateModel>> GetRealEstateById(int realEstateId)
        {
            var getRealEstateById = await _realEstateService.GetRealEstateByIdAsync(realEstateId);
            return getRealEstateById.IsSuccess ? Ok(getRealEstateById.Result) : Problem(getRealEstateById.ProblemType, getRealEstateById.AdditionalInformation.ToString());
        }

        [HttpDelete("{realEstateId}", Name = "DeleteRealEstateById")]
        public async Task<ActionResult<RealEstateModel>> DeleteRealEstateByIdAsync(int realEstateId)
        {
            var deleteRealEstate = await _realEstateService.DeleteRealEstateByIdAsync(realEstateId);
            return deleteRealEstate.IsSuccess ? Ok(deleteRealEstate.Result) : Problem(deleteRealEstate.ProblemType, string.Join(",", deleteRealEstate.AdditionalInformation));
        }
    }
}