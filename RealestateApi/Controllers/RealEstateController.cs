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
        public async Task<ActionResult<List<RealEstateRequestDto>>> GetAllRealEstate()
        {
            var getAllRealEstate = await _realEstateService.GetAllRealEstateAsync();
            return getAllRealEstate.IsSuccess ? Ok(getAllRealEstate.Result) : Problem(getAllRealEstate.ProblemType, getAllRealEstate.AdditionalInformation.ToString());
        }

        [HttpPost(Name = "AddRealEstate")]
        public async Task<ActionResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            var addRealEstate = await _realEstateService.AddRealEstateAsync(realEstateDto);
            return addRealEstate.IsSuccess ? Ok(addRealEstate.Result) : Problem(addRealEstate.ProblemType, addRealEstate.AdditionalInformation.ToString());
        }

        [HttpGet("{realEstateId}", Name = "GetAllRealEstateById")]
        public async Task<ActionResult<RealEstateModel>> GetAllRealEstateById(int realEstateId)
        {
            var getAllRealEstateById = await _realEstateService.GetRealEstateByIdAsync(realEstateId);
            return getAllRealEstateById.IsSuccess ? Ok(getAllRealEstateById.Result) : Problem(getAllRealEstateById.ProblemType, getAllRealEstateById.AdditionalInformation.ToString());
        }
    }
}