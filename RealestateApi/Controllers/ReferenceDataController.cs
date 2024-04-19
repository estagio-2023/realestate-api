using RealEstateApi.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Service.Interfaces;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceDataController : ControllerBase
    {
        private readonly ILogger<ReferenceDataController> _logger;
        private readonly IReferenceDataService _referenceDataService;

        public ReferenceDataController(ILogger<ReferenceDataController> logger, IReferenceDataService referenceDataService)
        {
            _logger = logger;
            _referenceDataService = referenceDataService;
        }

        [HttpGet(Name = "GetAllReferenceData")]
        public async Task<ReferenceDataResponseDto> Get()
        {
            return await _referenceDataService.GetAllReferenceDataAsync();
        }

        [HttpPost("{referenceDataType}", Name = "AddReferenceData")]
        public async Task<ReferenceDataModel> AddReferenceDataAsync(string referenceDataType, ReferenceDataRequestDto refData)
        {
            return await _referenceDataService.AddReferenceDataAsync(referenceDataType, refData);
        }

        [HttpDelete("{refDataType}/{refDataId}", Name = "DeleteRefData")]
        public async Task<ReferenceDataResponseDto> DeleteReferenceDataAsync(string refDataType, int refDataId)
        {
            try
            {
                return await _referenceDataService.DeleteReferenceDataAsync(refDataType, refDataId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving reference data.");
                throw;
            }
        }

        [HttpGet("{refDataType}/{refDataId}", Name = "ReferenceData")]
        public async Task<ReferenceDataModel> GetReferenceDataAsync(string refDataType, int refDataId)
        {
            return await _referenceDataService.GetReferenceDataAsync(refDataType, refDataId);
        }
    }
}