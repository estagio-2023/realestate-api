using AppCasasAPI.Dto.Response;
using AppCasasAPI.Repository.Interfaces;
using AppCasasAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AppCasasAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReferenceDataController : ControllerBase
    {
        private readonly ILogger<ReferenceDataController> _logger;
        private readonly IReferenceDataRepository _referenceDataRepository;
        private readonly IReferenceDataService _referenceDataService;

        public ReferenceDataController(ILogger<ReferenceDataController> logger, IReferenceDataRepository referenceDataRepository, IReferenceDataService referenceDataService)
        {
            _logger = logger;
            _referenceDataRepository = referenceDataRepository;
            _referenceDataService = referenceDataService;
        }

        [HttpGet(Name = "GetAllReferenceData")]
        public async Task<ReferenceDataResponseDto> GetAllReferenceData()
        {
            return await _referenceDataRepository.GetAllReferenceDataAsync();

        }


        [HttpPost("{referenceDataType}", Name = "AddReferenceData")]

        //referenceDataType is a variable that stores the parameter by the user
        public async Task<AddReferenceDataResponseDto> AddReferenceDataAsync(string referenceDataType, ReferenceDataRequestDto refData)
        {
            return await _referenceDataService.AddReferenceDataAsync(referenceDataType, refData);
        }
    }
}