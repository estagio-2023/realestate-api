using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

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
    }
}
