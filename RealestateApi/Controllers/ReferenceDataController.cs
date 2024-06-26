using RealEstateApi.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Service.Interfaces;
using RealEstateApi.Dto.Request;
using FluentValidation;
using RealEstateApi.Enums;
using RealEstateApi.Helpers;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceDataController : ControllerBase
    {
        private readonly ILogger<ReferenceDataController> _logger;
        private readonly IReferenceDataService _referenceDataService;
        private readonly IValidator<ReferenceDataRequestDto> _referencDataRequestValidatorDto;
        
        public ReferenceDataController(ILogger<ReferenceDataController> logger, IReferenceDataService referenceDataService, IValidator<ReferenceDataRequestDto> referenceDataRequestValidatorDto)
        {
            _logger = logger;
            _referenceDataService = referenceDataService;
            _referencDataRequestValidatorDto = referenceDataRequestValidatorDto;
            
        }

        /// <summary>
        /// 
        /// Https Get Method to get all Reference Data
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        ///     
        ///     GET api/ReferenceData/
        /// 
        /// <returns> ReferenceDataResponseDto </returns>
        [HttpGet(Name = "GetAllReferenceData")]
        public async Task<ActionResult<ReferenceDataResponseDto>> GetAllReferenceDataAsync()
        {
            var response = await _referenceDataService.GetAllReferenceDataAsync();

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https POST Method to post a Reference Data
        /// 
        /// </summary>
        /// <param name="referenceDataType"></param>
        /// 
        /// Sample Request:
        ///     
        ///     POST api/ReferenceData/{referenceDataType}   
        /// 
        /// <returns> ReferenceDataModel </returns>
        [HttpPost("{referenceDataType}", Name = "AddReferenceData")]
        public async Task<ActionResult<ReferenceDataResponseDto>> AddReferenceDataAsync(string referenceDataType, ReferenceDataRequestDto refData)
        {
            if (!ValidateReferenceDataType(referenceDataType))
            {
                return Problem(ProblemTypes.InvalidType,"Invalid Reference Data Type",(int)HttpCodesEnum.BadRequest);
            }

            var response = await _referenceDataService.AddReferenceDataAsync(referenceDataType, refData);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https Delete Method to delete a Reference Data Model by Id
        /// 
        /// </summary>
        /// <param name="refDataType"></param>
        /// <param name="refDataId"></param>
        /// 
        /// Sample Request:
        ///     
        ///     DELETE api/ReferenceData/{refDataType}/{refDataId}    
        /// 
        /// <returns> ReferenceDataModel </returns>
        [HttpDelete("{refDataType}/{refDataId}", Name = "DeleteRefData")]
        public async Task<ActionResult<ReferenceDataResponseDto>> DeleteReferenceDataAsync(string refDataType, int refDataId)
        {
            if (!ValidateReferenceDataType(refDataType))
            {
                return Problem(ProblemTypes.InvalidType, "Invalid Reference Data Type",(int)HttpCodesEnum.BadRequest);
            }

             var deleteRefData = await _referenceDataService.DeleteReferenceDataAsync(refDataType, refDataId);
             return deleteRefData.IsSuccess ? Ok(deleteRefData.Result) : Problem(deleteRefData.ProblemType, string.Join(",", deleteRefData.AdditionalInformation));
        }

        /// <summary>
        /// 
        /// Https Get Method to get a Reference Data by Id
        /// 
        /// </summary>
        /// <param name="refDataType"></param>
        /// <param name="refDataId"></param>
        /// 
        /// Sample Request:
        ///     
        ///     GET api/ReferenceData/{refDataType}/{refDataId}    
        /// 
        /// <returns> ReferenceDataModel </returns>
        [HttpGet("{refDataType}/{refDataId}", Name = "ReferenceData")]
        public async Task<ActionResult<ReferenceDataResponseDto>> GetReferenceDataByIdAsync(string refDataType, int refDataId)
        {
            if (!ValidateReferenceDataType(refDataType))
            {
                return Problem(ProblemTypes.InvalidType, "Invalid Reference Data Type", (int)HttpCodesEnum.BadRequest);
            }

            var response = await _referenceDataService.GetReferenceDataByIdAsync(refDataType, refDataId);

            return response.IsSuccess 
                ? Ok(response.Result) 
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        private static bool ValidateReferenceDataType(string referenceDataType)
        {
            return Enum.IsDefined(typeof(RefDataEnum), referenceDataType);
        }
    }
}