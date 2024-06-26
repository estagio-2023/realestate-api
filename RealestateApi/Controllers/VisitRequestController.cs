using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Enums;
using RealEstateApi.Helpers;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitRequestController : ControllerBase
    {
        private readonly IVisitRequestService _visitRequestService;
        private readonly IValidator<VisitRequestAvailabilityDto> _visitRequestAvailabilityValidator;

        public VisitRequestController(IVisitRequestService visitRequestService, IValidator<VisitRequestAvailabilityDto> visitRequestAvailabilityValidator)
        {
            _visitRequestService = visitRequestService;
            _visitRequestAvailabilityValidator = visitRequestAvailabilityValidator;

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
        public async Task<ActionResult<List<VisitRequestResponseDto>>> GetAllVisitRequestsAsync()
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
        /// <returns> VisitRequestResponseDto </returns>
        [HttpGet("{visitRequestId}", Name = "GetVisitRequestById")]
        public async Task<ActionResult<VisitRequestResponseDto>> GetVisitRequestByIdAsync(int visitRequestId)
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
        /// <returns> VisitRequestResponseDto </returns>
        [HttpPut("{visitRequestId}/Confirmation", Name = "UpdateVisitRequestById")]
        public async Task<ActionResult<VisitRequestResponseDto>> UpdateVisitRequestConfirmationByIdAsync(int visitRequestId)
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
        /// <returns> VisitRequestResponseDto </returns>
        [HttpGet("RealEstate/{realEstateId}", Name = "GetAllVisitRequestsByRealEstateId")]
        public async Task<ActionResult<VisitRequestResponseDto>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId)
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
        /// <returns> VisitRequestResponseDto </returns>
        [HttpPost(Name = "AddVisitRequest")]
        public async Task<ActionResult<VisitRequestResponseDto>> AddVisitRequestAsync(VisitRequestDto visitRequestData)
        {
            var response = await _visitRequestService.AddVisitRequestAsync(visitRequestData);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

        /// <summary>
        /// 
        /// Get the availability of the visit request based on the parameters
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="realEstateId"></param>
        /// <param name="agentId"></param>
        /// <returns> VisitRequestAvailabilityDto </returns>
        [HttpGet("Availability", Name = "GetVisitRequestAvailability")]
        public async Task<ActionResult<VisitRequestAvailabilityDto>> GetVisitRequestAvailabilityAsync([FromQuery] string date, [FromQuery] string startTime, [FromQuery] string endTime, [FromQuery] int realEstateId, [FromQuery] int agentId)
        {
            var visitRequestData = VisitRequestAvailabilityDto.BuildFrom(date,startTime,endTime,realEstateId, agentId);

            var validationResult = _visitRequestAvailabilityValidator.Validate(visitRequestData);
            if (!validationResult.IsValid)
            {
                return Problem(ProblemTypes.ValidationError, string.Join(",", validationResult.Errors));
            }
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
        /// <returns> VisitRequestResponseDto </returns>
        [HttpDelete("{visitRequestId}", Name = "DeleteVisitRequestById")]
        public async Task<ActionResult<VisitRequestResponseDto>> DeleteVisitRequestByIdAsync(int visitRequestId)
        {
            var deleteVisitRequest = await _visitRequestService.DeleteVisitRequestByIdAsync(visitRequestId);
            return deleteVisitRequest.IsSuccess ? Ok(deleteVisitRequest.Result) : Problem(deleteVisitRequest.ProblemType, string.Join(",", deleteVisitRequest.AdditionalInformation));
        }
    }
}