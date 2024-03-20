using AppCasasAPI.Dto.Response;
using AppCasasAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppCasasAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReferenceDataController : ControllerBase
    {
        private readonly ILogger<ReferenceDataController> _logger;
        private readonly IReferenceDataRepository _referenceDataRepository;

        public ReferenceDataController(ILogger<ReferenceDataController> logger, IReferenceDataRepository referenceDataRepository)
        {
            _logger = logger;
            _referenceDataRepository = referenceDataRepository;
        }

        [HttpGet(Name = "GetAllReferenceData")]
        public async Task<ReferenceDataResponseDto> GetAllReferenceData()
        {
            return await _referenceDataRepository.GetAllReferenceDataAsync();

        }


        [HttpPost("{referenceDataType}", Name = "AddReferenceData")]

        //referenceDataType is a variable that stores the parameter by the user
        public async Task<ReferenceDataResponseDto> AddReferenceDataAsync(string referenceDataType)
        {
            return await _referenceDataRepository.GetAllReferenceDataAsync();

        }

    }
}
