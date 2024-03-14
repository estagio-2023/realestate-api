using AppCasasAPI.Dto.Response;
using AppCasasAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace AppCasasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceDataController : ControllerBase
    {
        private readonly ILogger<ReferenceDataController> _logger;
        private readonly IReferenceDataRepository _referenceDataRepository;

        public ReferenceDataController(ILogger<ReferenceDataController> logger,IReferenceDataRepository referenceDataRepository)
        {
            _logger = logger;   
            _referenceDataRepository = referenceDataRepository;
        }

        [HttpGet(Name = "GetAllReferenceData")]
        public async Task<ReferenceDataResponseDto> Get()
        {
            return await _referenceDataRepository.GetAllReferenceDataAsync();
           
        }
    }
}
