﻿using Microsoft.AspNetCore.Mvc;
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
        /// HTTPs Get Method to gather a List of all Visit Requests by Id
        /// 
        /// </summary>
        /// 
        /// Sample Request:
        /// 
        ///     GET /api/VisitRequests/{realestateId}
        /// 
        /// <param name="realestateId"> Id of fk_realestate_id </param>
        /// <returns> List<VisitRequestModel> </returns>
        [HttpGet("{realestateId}", Name = "GetAllRealEstateById")]
        public async Task<ActionResult<List<VisitRequestModel>>> GetAllVisitRequestsByIdAsync(int realestateId)
        {
            var response = await _visitRequestService.GetAllVisitRequestsByIdAsync(realestateId);

            return response.IsSuccess
                ? Ok(response.Result)
                : Problem(response.ProblemType, string.Join(",", response.AdditionalInformation), (int)HttpCodesEnum.BadRequest);
        }

    }
}
