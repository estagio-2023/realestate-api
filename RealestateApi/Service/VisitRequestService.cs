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
    }
}
