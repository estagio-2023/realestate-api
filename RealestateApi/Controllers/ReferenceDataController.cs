using RealEstateApi.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Service.Interfaces;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using FluentValidation;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceDataController : ControllerBase
    {
        private readonly ILogger<ReferenceDataController> _logger;
        private readonly IReferenceDataService _referenceDataService;
        private readonly IValidator<ReferenceDataRequestDto> _referencDataRequestValidatorDto;
        private readonly IValidator<DeleteRefDataRequestDto> _deleteReferenceDataRequestValidatorDto;

        public ReferenceDataController(ILogger<ReferenceDataController> logger, IReferenceDataService referenceDataService, IValidator<ReferenceDataRequestDto> referenceDataRequestValidatorDto, IValidator<DeleteRefDataRequestDto> deleteReferenceDataRequestValidatorDto)
        {
            _logger = logger;
            _referenceDataService = referenceDataService;
            _referencDataRequestValidatorDto = referenceDataRequestValidatorDto;
            _deleteReferenceDataRequestValidatorDto = deleteReferenceDataRequestValidatorDto;
        }

        [HttpGet(Name = "GetAllReferenceData")]
        public async Task<ReferenceDataResponseDto> Get()
        {
            return await _referenceDataService.GetAllReferenceDataAsync();
        }

        [HttpPost("{referenceDataType}", Name = "AddReferenceData")]
        public async Task<ReferenceDataModel> AddReferenceDataAsync(string referenceDataType, ReferenceDataRequestDto refData)
        {
            var validationResult = _referencDataRequestValidatorDto.Validate(refData);

            if (!validationResult.IsValid)
            {
                return new ReferenceDataModel();
            }

            return await _referenceDataService.AddReferenceDataAsync(referenceDataType, refData);
        }

        [HttpDelete("{refDataType}/{refDataId}", Name = "DeleteRefData")]
        public async Task<ReferenceDataResponseDto> DeleteReferenceDataAsync(string refDataType, int refDataId, DeleteRefDataRequestDto delRefData)
        {
            try
            {
                var validationResult = _deleteReferenceDataRequestValidatorDto.Validate(delRefData);

                if (!validationResult.IsValid)
                {
                    return new ReferenceDataResponseDto();
                }

                return await _referenceDataService.DeleteReferenceDataAsync(refDataType, refDataId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving reference data.");
                throw;
            }
        }

        [HttpGet("{refDataType}/{refDataId}", Name = "ReferenceData")]
        public async Task<ReferenceDataModel> GetReferenceDataByIdAsync(string refDataType, int refDataId)
        {
            return await _referenceDataService.GetReferenceDataByIdAsync(refDataType, refDataId);
        }
    }
}