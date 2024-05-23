using RealEstateApi.Model;
using RealEstateApi.Repository;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;
using System.Collections.Generic;

namespace RealEstateApi.Service
{
    public class VisitRequestService: IVisitRequestService
    {
        private readonly IVisitRequestRepository _visitRequestRepository;

        public VisitRequestService(IVisitRequestRepository visitRequestRepository)
        {
            _visitRequestRepository = visitRequestRepository;
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
        /// Gathers a List of all Visit Requests by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id of fk_realestate_id </param>
        /// <returns> List<VisitRequestModel> </returns>
        public async Task<ServiceResult<List<VisitRequestModel>>> GetAllVisitRequestsByIdAsync(int realEstateId)
        {
            ServiceResult<List<VisitRequestModel>> response = new();

            try
            {
                var result = await _visitRequestRepository.GetAllVisitRequestsByIdAsync(realEstateId);

                if (result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Real Estate ID {realEstateId} was not found.");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to get real estate ID: {realEstateId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }
    }   
}
