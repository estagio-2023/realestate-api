using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Enums;
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

        public RealEstateController(ILogger<RealEstateController> logger, IRealEstateService realEstateService, IValidator<AddRealEstateRequestDto> realEstateRequestValidatorDto)
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
        /// <returns> RealEstateModel </returns>
        [HttpPost(Name = "AddRealEstate")]
        public async Task<ActionResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
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
        /// <returns> RealEstateModel </returns>
        [HttpGet("{realEstateId}", Name = "GetRealEstateById")]
        public async Task<ActionResult<RealEstateModel>> GetRealEstateById(int realEstateId)
        {
            var response = await _realEstateService.GetRealEstateByIdAsync(realEstateId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        [HttpDelete("{realEstateId}", Name = "DeleteRealEstateById")]
        public async Task<ActionResult<RealEstateModel>> DeleteRealEstateByIdAsync(int realEstateId)
        {
            var response = await _realEstateService.DeleteRealEstateByIdAsync(realEstateId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
    }
}