using Microsoft.AspNetCore.Mvc.Diagnostics;
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
                }else
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
        /// Updates a Visit Request confirmation by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to update a Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<ServiceResult<VisitRequestModel>> PutVisitRequestConfirmationByIdAsync(int visitRequestId)
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

                var result = await _visitRequestRepository.PutVisitRequestConfirmationByIdAsync(visitRequestId);

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
        public async Task<ServiceResult<VisitRequestModel>> PostVisitRequestAsync(VisitRequestDto visitRequestData)
        {
            ServiceResult<VisitRequestModel> response = new();

            try
            {
                var existingRealEstate = await _referenceDataRepository.GetRealEstateReferenceDataAsync(RefDataEnum.realestate_type.ToString(), visitRequestData.FkRealEstateId);
                if (existingRealEstate == null)
                {
                    response.AdditionalInformation.Add($"Real estate ID {visitRequestData.FkRealEstateId} was not found.");
                    return response;
                }

                var existingAgent = await _agentRepository.GetAgentByIdAsync(visitRequestData.FkAgentId);
                if (existingAgent == null)
                {
                    response.AdditionalInformation.Add($"Agent ID {visitRequestData.FkAgentId} was not found.");
                    return response;
                }

                var realestate = await _visitRequestRepository.ExistingRealEstateId(visitRequestData);
                if(realestate == false)
                {
                    response.AdditionalInformation.Add($"There is already a visit request scheduled for this Real estate ID: {visitRequestData.FkRealEstateId}.");
                    return response;
                }

                var agent = await _visitRequestRepository.ExistingAgentId(visitRequestData);
                if (agent == false)
                {
                    response.AdditionalInformation.Add($"There is already a visit request scheduled for this Agent ID {visitRequestData.FkAgentId}.");
                    return response;
                }

                var result = await _visitRequestRepository.PostVisitRequestAsync(visitRequestData);
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
    }
}
