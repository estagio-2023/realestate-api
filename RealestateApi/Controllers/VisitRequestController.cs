using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Enums;
using RealEstateApi.Model;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitRequestController: ControllerBase
    {
        private readonly IVisitRequestService _visitRequestService;

        public VisitRequestController(IVisitRequestService visitRequestService)
        {
            _visitRequestService = visitRequestService;
        }

        [HttpGet(Name = "GetAllVisistRequests")]
        public async Task<ActionResult<List<VisitRequestModel>>> GetAllVisistRequestsAsync()
        {
            var response = await _visitRequestService.GetAllVisistRequestsAsync();

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
    }
}
