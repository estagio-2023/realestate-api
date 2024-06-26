using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Enums;
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
        /// <returns> List<RealEstateResponseDto> </returns>
        [HttpGet(Name = "GetAllRealEstate")]
        public async Task<ActionResult<List<RealEstateResponseDto>>> GetAllRealEstate()
        {
            var response = await _realEstateService.GetAllRealEstateAsync();

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
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
        /// <returns> RealEstateResponseDto </returns>
        [HttpPost(Name = "AddRealEstate")]
        public async Task<ActionResult<RealEstateResponseDto>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            var response = await _realEstateService.AddRealEstateAsync(realEstateDto);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
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
        /// <returns> RealEstateResponseDto </returns>
        [HttpGet("{realEstateId}", Name = "GetRealEstateById")]
        public async Task<ActionResult<RealEstateResponseDto>> GetRealEstateById(int realEstateId)
        {
            var response = await _realEstateService.GetRealEstateByIdAsync(realEstateId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https Delete Method to delete a Real Estate by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get Real Estate </param>
        /// 
        ///  Sample Request:
        /// 
        ///     DELETE api/RealEstate/{realEstateId}
        ///     
        /// <returns> RealEstateResponseDto </returns>
        [HttpDelete("{realEstateId}", Name = "DeleteRealEstateById")]
        public async Task<ActionResult<RealEstateResponseDto>> DeleteRealEstateByIdAsync(int realEstateId)
        {
            var response = await _realEstateService.DeleteRealEstateByIdAsync(realEstateId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
    }
}