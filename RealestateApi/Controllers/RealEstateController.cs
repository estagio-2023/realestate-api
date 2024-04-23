using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
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

        [HttpGet(Name = "GetAllRealEstate")]
        public async Task<List<RealEstateRequestDto>> GetAllRealEstate()
        {
            return await _realEstateService.GetAllRealEstateAsync();
        }

        [HttpPost(Name = "AddRealEstate")]
        public async Task<RealEstateModel> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            return await _realEstateService.AddRealEstateAsync(realEstateDto);
        }
    }
}