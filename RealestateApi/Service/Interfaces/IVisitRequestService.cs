using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IVisitRequestService
    {
        /// <summary>
        /// 
        /// Gathers a List of all Visit Requests
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        Task<ServiceResult<List<VisitRequestModel>>> GetAllVisitRequestsAsync();

        /// <summary>
        /// 
        /// Gets a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        Task<ServiceResult<VisitRequestModel?>> GetVisitRequestByIdAsync(int visitRequestId);

        /// <summary>
        /// 
        /// Gathers a List of all Visit Requests
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        Task<ServiceResult<List<VisitRequestModel>>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId);
    }
}
