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
        /// Https Put Method to updated a Visit Request confirmation
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to update a Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        [HttpPut("{visitRequestId}", Name = "PutVisitRequestById")]
        public async Task<ActionResult<VisitRequestModel>> PutVisitRequestConfirmationByIdAsync(int visitRequestId)
        {
            var response = await _visitRequestService.PutVisitRequestConfirmationByIdAsync(visitRequestId);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        [HttpPost(Name = "PostVisitRequest")]
        public async Task<ActionResult<VisitRequestModel>> PostVisitRequestAsync(VisitRequestDto visitRequestData)
        {
            var response = await _visitRequestService.PostVisitRequestAsync(visitRequestData);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }
    }
}
