﻿using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Enums;
using RealEstateApi.Model;
using RealEstateApi.Repository;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;
using System.Data.Common;

namespace RealEstateApi.Service
{
    public class VisitRequestService: IVisitRequestService
    {
        private readonly IVisitRequestRepository _visitRequestRepository;
        private readonly IReferenceDataRepository _referenceDataRepository;
        private readonly IAgentRepository _agentRepository;

        public VisitRequestService(IVisitRequestRepository visitRequestRepository, IReferenceDataRepository referenceDataRepository, IAgentRepository agentRepository)
        {
            _visitRequestRepository = visitRequestRepository;
            _visitRequestRepository = visitRequestRepository;
            _referenceDataRepository = referenceDataRepository;
            _agentRepository = agentRepository;
        }

        /// <summary>
        /// 
        /// Gathers a List of all Visit Requests
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        public async Task<ServiceResult<List<VisitRequestModel>>> GetAllVisitRequestsAsync()
        {
            ServiceResult<List<VisitRequestModel>> response = new();

            try
            {
                var result = await _visitRequestRepository.GetAllVisitRequestsAsync();

                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add("There was an error while trying to retrieve all visit requests.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gets a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<ServiceResult<VisitRequestModel?>> GetVisitRequestByIdAsync(int visitRequestId)
        {
            ServiceResult<VisitRequestModel?> response = new();

            try
            {
                var result = await _visitRequestRepository.GetVisitRequestByIdAsync(visitRequestId);

                if(result != null) {
                    response.IsSuccess = true;
                    response.Result = result;
                }
                else
                {
                    response.Result = null;
                    response.AdditionalInformation.Add($"Visit request ID {visitRequestId} was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add($"There was an error while trying to get visit request ID: {visitRequestId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Updates Visit Request confirmation by Visit Request Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Visit request Id to update Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<ServiceResult<VisitRequestModel>> UpdateVisitRequestConfirmationByIdAsync(int visitRequestId)
        {
            ServiceResult<VisitRequestModel> response = new();

            try
            {
                var existingVisitRequest = await _visitRequestRepository.GetVisitRequestByIdAsync(visitRequestId);

                if(existingVisitRequest == null) 
                {
                    response.AdditionalInformation.Add($"Visit request with ID {visitRequestId} was not found");
                    return response;
                }

                var result = await _visitRequestRepository.UpdateVisitRequestConfirmationByIdAsync(visitRequestId);

                if(result != null) 
                {
                    response.IsSuccess = true;
                    response.Result = result;
                }
            }
            catch (Exception ex) 
            {
                response.AdditionalInformation.Add($"There was an error while trying to update Visit Request confirmation.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Creates a Visit Request
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to be saved </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<ServiceResult<VisitRequestModel>> AddVisitRequestAsync(VisitRequestDto visitRequestData)
        {
            ServiceResult<VisitRequestModel> response = new();

            try
            {
                var existingRealEstate = await _referenceDataRepository.GetRealEstateReferenceDataAsync(visitRequestData.RealEstateId);
                if (existingRealEstate == null)
                {
                    response.AdditionalInformation.Add($"Real estate ID {visitRequestData.RealEstateId} was not found.");
                    return response;
                }

                var existingAgent = await _agentRepository.GetAgentByIdAsync(visitRequestData.AgentId);
                if (existingAgent == null)
                {
                    response.AdditionalInformation.Add($"Agent ID {visitRequestData.AgentId} was not found.");
                    return response;
                }

                var existingRealEstateVisitRequest = await _visitRequestRepository.ExistingRealEstateId(visitRequestData.RealEstateId, visitRequestData.Date, visitRequestData.StartTime, visitRequestData.EndTime);
                if(!existingRealEstateVisitRequest)
                {
                    response.AdditionalInformation.Add($"There is already a visit request scheduled for this Real estate ID: {visitRequestData.RealEstateId}.");
                    return response;
                }

                var existingAgentVisitRequest = await _visitRequestRepository.ExistingAgentId(visitRequestData.AgentId, visitRequestData.Date, visitRequestData.StartTime, visitRequestData.EndTime);
                if (!existingAgentVisitRequest)
                {
                    response.AdditionalInformation.Add($"There is already a visit request scheduled for this Agent ID {visitRequestData.AgentId}.");
                    return response;
                }

                var result = await _visitRequestRepository.AddVisitRequestAsync(visitRequestData);
                if(result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add($"There was an error while trying to add Visit Request {visitRequestData.Name}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gathers a List of all Visit Requests
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        public async Task<ServiceResult<List<VisitRequestModel>>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId)
        {
            ServiceResult<List<VisitRequestModel>> response = new();

            try
            {
                var result = await _visitRequestRepository.GetAllVisitRequestsByRealEstateIdAsync(realEstateId);

                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add("There was an error while trying to retrieve all visit requests by realestate id.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }   

        /// <summary>
        /// 
        /// Deletes a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<ServiceResult<VisitRequestModel>> DeleteVisitRequestByIdAsync(int visitRequestId)
        {
            ServiceResult<VisitRequestModel> response = new();

            try
            {
                var existingVisitRequest = await _visitRequestRepository.GetVisitRequestByIdAsync(visitRequestId);

                if (existingVisitRequest == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Visit Request with ID {visitRequestId} was not found");
                    return response;
                }
                var result = await _visitRequestRepository.DeleteVisitRequestByIdAsync(visitRequestId);

                if (result)
                {
                    response.IsSuccess = true;
                    response.Result = existingVisitRequest;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete visit request ID: {visitRequestId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Get the availability of the visit request based on the parameters
        /// 
        /// </summary>
        /// <param name="visitRequestData"></param>
        /// <returns></returns>
        public async Task<ServiceResult<VisitRequestModel>> GetVisitRequestAvailabilityAsync(VisitRequestAvailabilityDto visitRequestData)
        {
            ServiceResult<VisitRequestModel> response = new();
            try
            {
                var existingRealEstate = await _referenceDataRepository.GetRealEstateReferenceDataAsync(visitRequestData.RealEstateId);
                if (existingRealEstate == null)
                {
                    response.AdditionalInformation.Add($"Real estate ID {visitRequestData.RealEstateId} was not found.");
                    return response;
                }

                var existingAgent = await _agentRepository.GetAgentByIdAsync(visitRequestData.AgentId);
                if (existingAgent == null)
                {
                    response.AdditionalInformation.Add($"Agent ID {visitRequestData.AgentId} was not found.");
                    return response;
                }

                if (!await _visitRequestRepository.ExistingAgentId(visitRequestData.AgentId, visitRequestData.Date, visitRequestData.StartTime, visitRequestData.EndTime))
                {
                    response.AdditionalInformation.Add($"Agent not available at this time");
                    return response;
                }

                if (!await _visitRequestRepository.ExistingRealEstateId(visitRequestData.RealEstateId, visitRequestData.Date, visitRequestData.StartTime, visitRequestData.EndTime))
                {
                    response.AdditionalInformation.Add($"Real Estate not available at this time");
                    return response;
                }

                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add($"There was an error while trying to get visit request availability");
                response.AdditionalInformation.Add(ex.Message);
            }
        
            return response;
        }

    }
}