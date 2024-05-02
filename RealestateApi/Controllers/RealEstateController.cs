using FluentValidation;
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
        private readonly IValidator<AddRealEstateRequestDto> _realEstateRequestValidatorDto;

        public RealEstateController(ILogger<RealEstateController> logger, IRealEstateService realEstateService, IValidator<AddRealEstateRequestDto> realEstateRequestValidatorDto)
        {
            _logger = logger;
            _realEstateService = realEstateService;
            _realEstateRequestValidatorDto = realEstateRequestValidatorDto;
        }

        [HttpGet(Name = "GetAllRealEstate")]
        public async Task<List<RealEstateRequestDto>> GetAllRealEstate()
        {
            return await _realEstateService.GetAllRealEstateAsync();
        }

        [HttpPost(Name = "AddRealEstate")]
        public async Task<RealEstateModel> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            var validationResult = _realEstateRequestValidatorDto.Validate(realEstateDto);

            if (!validationResult.IsValid)
            {
                return new RealEstateModel();
            }

            return await _realEstateService.AddRealEstateAsync(realEstateDto);
        }

        [HttpGet("{realEstateId}", Name = "GetAllRealEstateById")]
        public async Task<RealEstateModel> GetAllRealEstateById(int realEstateId)
        {
            return await _realEstateService.GetRealEstateByIdAsync(realEstateId);
        }
    }
}