using RealEstateApi.Dto.Request;
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
        /// Updates a Visit Request confirmation
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to update a Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        Task<VisitRequestModel?> PutVisitRequestConfirmationByIdAsync(int visitRequestId);

        /// <summary>
        /// 
        /// Deletes a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns></returns>
        Task<bool> DeleteVisitRequestByIdAsync(int visitRequestId);

        /// <summary>
        /// 
        /// Gets a List of all Visit Requests by Realestate Id from Database
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        Task<List<VisitRequestModel>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId);
    }
}
