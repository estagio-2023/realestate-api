using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IVisitRequestRepository
    {
        /// <summary>
        /// 
        /// Gather a List of all Visit Requests
        /// 
        /// </summary>
        /// <returns> <List<VisitRequestModel> </returns>
        Task<List<VisitRequestModel>> GetAllVisitRequestsAsync();

        /// <summary>
        /// 
        /// Gets a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        Task<VisitRequestModel?> GetVisitRequestByIdAsync(int visitRequestId);

        /// <summary>
        /// 
        /// Gets a List of all Visit Requests by Realestate Id from Database
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        Task<List<VisitRequestModel>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId);
    }
}
