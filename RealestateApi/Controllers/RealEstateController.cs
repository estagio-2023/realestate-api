using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
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

        [HttpGet(Name = "GetAllRealEstate")]
        public async Task<ServiceResult<List<RealEstateRequestDto>>> GetAllRealEstate()
        {
            return await _realEstateService.GetAllRealEstateAsync();
        }

        [HttpPost(Name = "AddRealEstate")]
        public async Task<ActionResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            var addRealEstate = await _realEstateService.AddRealEstateAsync(realEstateDto);
            return addRealEstate.IsSuccess ? Ok(addRealEstate.Result) : Problem(addRealEstate.ProblemType, addRealEstate.AdditionalInformation.ToString());

        }
    }
}