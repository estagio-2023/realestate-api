using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
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
        /// Https get method to gather a list of all real estates
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/RealEstate
        /// 
        /// <returns><List<RealEstateRequestDto></returns>
        [HttpGet(Name = "GetAllRealEstate")]
        public async Task<ActionResult<List<RealEstateRequestDto>>> GetAllRealEstate()
        {
            var getAllRealEstate = await _realEstateService.GetAllRealEstateAsync();
            return getAllRealEstate.IsSuccess ? Ok(getAllRealEstate.Result) : Problem(getAllRealEstate.ProblemType, getAllRealEstate.AdditionalInformation.ToString());
        }

        /// <summary>
        /// 
        /// Https post method to create a real estate
        /// 
        /// </summary>
        /// <param name="realEstateDto"> Real estate data to be saved </param>
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
        /// Https get method to get real estates by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get real estate </param>
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
    }
}