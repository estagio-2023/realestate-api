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
    }
}