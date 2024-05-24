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

        /// <summary>
        /// 
        /// Https Get Method to gather a List of all Visit Requests
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/VisitRequests
        /// 
        /// <returns> List<VisitRequestModel> </returns>
        [HttpGet(Name = "GetAllVisitRequests")]
        public async Task<ActionResult<List<VisitRequestModel>>> GetAllVisitRequestsAsync()
        {
            var response = await _visitRequestService.GetAllVisitRequestsAsync();

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https Get Method to a Visit Request by Id
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/VisitRequest/{visitRequestId}
        /// 
        /// <returns> VisitRequestModel </returns>
        [HttpGet("{visitRequestId}", Name = "GetVisitRequestById")]
        public async Task<ActionResult<VisitRequestModel>> GetVisitRequestByIdAsync(int visitRequestId)
        {
            var response = await _visitRequestService.GetVisitRequestByIdAsync(visitRequestId);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Https method to get all Visit Requests by RealEstateId
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/VisitRequest/RealEstate/{realEstateId}
        /// 
        /// <returns> VisitRequestModel </returns>
        [HttpGet("RealEstate/{realEstateId}", Name = "GetAllVisitRequestsByRealEstateId")]
        public async Task<ActionResult<VisitRequestModel>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId)
        {
            var response = await _visitRequestService.GetAllVisitRequestsByRealEstateIdAsync(realEstateId);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
    }
}
