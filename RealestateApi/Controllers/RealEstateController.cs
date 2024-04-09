using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Service;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealEstateController : ControllerBase
    {
        private readonly ILogger<RealEstateController> _logger;
        private readonly IRealEstateService _realEstateService;

        public RealEstateController(ILogger<RealEstateController> logger, IRealEstateService realEstateService)
        {
            _logger = logger;
            _realEstateService = realEstateService;
        }        

        [HttpGet(Name = "GetRealEstate")]
        public async Task<RealEstateResponseDto> GetRealEstate() 
        {
            return await _realEstateService.GetRealEstateAsync();
        }
    }
}
