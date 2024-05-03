using RealEstateApi.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Service.Interfaces;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
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
        public async Task<ActionResult<ReferenceDataResponseDto>> Get()
        {
            var getAllReferenceData = await _referenceDataService.GetAllReferenceDataAsync();
            return getAllReferenceData.IsSuccess ? Ok(getAllReferenceData.Result) : Problem(getAllReferenceData.ProblemType, getAllReferenceData.AdditionalInformation.ToString());
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
        public async Task<ActionResult<ReferenceDataModel>> AddReferenceDataAsync(string referenceDataType, ReferenceDataRequestDto refData)
        {
            var referenceDataTypeValidator = Enum.IsDefined(typeof(RefDataEnum), referenceDataType);

            if (!referenceDataTypeValidator)
            {
                return Problem(ProblemTypes.InvalidType,"Invalid Reference Data Type",(int)HttpCodesEnum.BadRequest);
            }

            _referencDataRequestValidatorDto.Validate(refData);

            var addRefData = await _referenceDataService.AddReferenceDataAsync(referenceDataType, refData);
            return addRefData.IsSuccess ? Ok(addRefData.Result) : Problem(addRefData.ProblemType, addRefData.AdditionalInformation.ToString());
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
             var referenceDataTypeValidator = Enum.IsDefined(typeof(RefDataEnum), refDataType);

             if (!referenceDataTypeValidator)
             {
                 return Problem(ProblemTypes.InvalidType, "Invalid Reference Data Type",(int)HttpCodesEnum.BadRequest);
             }

             var existingReferenceData = await _referenceDataService.GetReferenceDataByIdAsync(refDataType, refDataId);

            if (existingReferenceData.Result == null)
            {
                return Problem(ProblemTypes.ResourceNotFound, $"Reference Data Type {refDataType} Reference Data ID {refDataId} Doesn't Exist", (int)HttpCodesEnum.BadRequest);
            }

             var deleteRefData = await _referenceDataService.DeleteReferenceDataAsync(refDataType, refDataId);
             return deleteRefData.IsSuccess ? Ok(deleteRefData.Result) : Problem(deleteRefData.ProblemType, deleteRefData.AdditionalInformation.ToString());
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
        public async Task<ActionResult<ReferenceDataModel>> GetReferenceDataByIdAsync(string refDataType, int refDataId)
        {
            var getRefDataById = await _referenceDataService.GetReferenceDataByIdAsync(refDataType, refDataId);
            return getRefDataById.IsSuccess ? Ok(getRefDataById.Result) : Problem(getRefDataById.ProblemType, getRefDataById.AdditionalInformation.ToString());
        }
    }
}