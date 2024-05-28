using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Enums;
using RealEstateApi.Model;
using RealEstateApi.Service;
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
        /// Https Get Method to gather a Visit Request by Id
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
        /// Https Put Method to update Visit Request confirmation
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to update Visit Request Confirmation </param>
        /// <returns> VisitRequestModel </returns>
        [HttpPut("{visitRequestId}/Confirmation", Name = "UpdateVisitRequestById")]
        public async Task<ActionResult<VisitRequestModel>> UpdateVisitRequestConfirmationByIdAsync(int visitRequestId)
        {
            var response = await _visitRequestService.UpdateVisitRequestConfirmationByIdAsync(visitRequestId);

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

        /// <summary>
        /// 
        /// Https Post Method to create a Visit Request
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to be created </param>
        /// 
        /// Sample Request:
        /// 
        ///     POST /api/VisitRequest
        ///     
        /// <returns> VisitRequestModel </returns>
        [HttpPost(Name = "AddVisitRequest")]
        public async Task<ActionResult<VisitRequestModel>> AddVisitRequestAsync(VisitRequestDto visitRequestData)
        {
            var response = await _visitRequestService.AddVisitRequestAsync(visitRequestData);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        [HttpGet("VisitRequest/Availability", Name = "GetVisitRequestAvailability")]
        public async Task<ActionResult<VisitRequestModel>> GetVisitRequestAvailabilityAsync(VisitRequestDto visitRequestData)
        {
            var response = await _visitRequestService.GetVisitRequestAvailabilityAsync(visitRequestData);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
        /// <summary>
        /// 
        /// Https Delete Method to delete a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get a Visit Request </param>
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