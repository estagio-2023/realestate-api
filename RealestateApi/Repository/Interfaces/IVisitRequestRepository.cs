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
        /// Updates Visit Request confirmation
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Visit Request Id to update Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        Task<VisitRequestModel?> UpdateVisitRequestConfirmationByIdAsync(int visitRequestId);

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

        /// <summary>
        /// 
        /// Save a Visit Request
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to be Saved </param>
        /// <returns> VisitRequestModel </returns>
        Task<VisitRequestModel?> AddVisitRequestAsync(VisitRequestDto visitRequestData);

        /// <summary>
        /// 
        /// Gets a Visit Request by realestate id, date, start_time and end_time
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to get Visit Request </param>
        /// <returns> bool </returns>
        Task<bool> ExistingRealEstateId(VisitRequestDto visitRequestData);

        /// <summary>
        /// 
        /// Gets a Visit Request by agent id, date, start_time and end_time
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to get Visit Request </param>
        /// <returns> bool </returns>
        Task<bool> ExistingAgentId(VisitRequestDto visitRequestData);
    }
}
