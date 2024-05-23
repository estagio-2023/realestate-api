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
        /// Gathers a List of all Visit Requests by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id of fk_realestate_id </param>
        /// <returns> List<VisitRequestModel> </returns>
        Task<ServiceResult<List<VisitRequestModel>>> GetAllVisitRequestsByIdAsync(int realEstateId);
    }
}
