using RealEstateApi.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Service.Interfaces;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Service;
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

        [HttpGet(Name = "GetAllReferenceData")]
        public async Task<ActionResult<ReferenceDataResponseDto>> Get()
        {
            var getAllReferenceData = await _referenceDataService.GetAllReferenceDataAsync();
            return getAllReferenceData.IsSuccess ? Ok(getAllReferenceData.Result) : Problem(getAllReferenceData.ProblemType, getAllReferenceData.AdditionalInformation.ToString());
        }

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

        [HttpDelete("{refDataType}/{refDataId}", Name = "DeleteRefData")]
        public async Task<ActionResult<ReferenceDataResponseDto>> DeleteReferenceDataAsync(string refDataType, int refDataId)
        {
            try
            {
                var deleteRefData = await _referenceDataService.DeleteReferenceDataAsync(refDataType, refDataId);
                return deleteRefData.IsSuccess ? Ok(deleteRefData.Result) : Problem(deleteRefData.ProblemType, deleteRefData.AdditionalInformation.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving reference data.");
                throw;
            }
        }

        [HttpGet("{refDataType}/{refDataId}", Name = "ReferenceData")]
        public async Task<ActionResult<ReferenceDataModel>> GetReferenceDataByIdAsync(string refDataType, int refDataId)
        {
            var getRefDataById = await _referenceDataService.GetReferenceDataByIdAsync(refDataType, refDataId);
            return getRefDataById.IsSuccess ? Ok(getRefDataById.Result) : Problem(getRefDataById.ProblemType, getRefDataById.AdditionalInformation.ToString());
        }
    }
}