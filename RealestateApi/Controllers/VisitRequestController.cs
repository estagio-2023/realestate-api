using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Enums;
using RealEstateApi.Model;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitRequestController : ControllerBase
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
        /// Https Get Method to an Visit Request by Id
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
        /// Https Delete Method to delete a Customer by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get a Customer </param>
        /// 
        /// Sample Request:
        /// 
        ///     DELETE /api/VisitRequest/{visitRequestId}
        /// 
        /// <returns> VisitRequestModel </returns>
        [HttpDelete("{visitRequestId}", Name = "DeleteVisitRequestById")]
        public async Task<ActionResult<VisitRequestModel>> DeleteVisitRequestByIdAsync(int visitRequestId)
        {
            var deleteVisitRequest = await _visitRequestService.DeleteVisitRequestByIdAsync(visitRequestId);
            return deleteVisitRequest.IsSuccess ? Ok(deleteVisitRequest.Result) : Problem(deleteVisitRequest.ProblemType, string.Join(",", deleteVisitRequest.AdditionalInformation));
        }
    }
}