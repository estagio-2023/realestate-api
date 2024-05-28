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
        /// Save a Visit Request
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to be Saved </param>
        /// <returns> VisitRequestModel </returns>
        Task<VisitRequestModel?> PostVisitRequestAsync(VisitRequestDto visitRequestData);

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
