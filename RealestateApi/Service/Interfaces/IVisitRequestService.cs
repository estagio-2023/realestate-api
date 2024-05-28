using RealEstateApi.Dto.Request;
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
        /// Updates a Visit Request confirmation
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to update a Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        Task<ServiceResult<VisitRequestModel>> PutVisitRequestConfirmationByIdAsync(int visitRequestId);

        /// <summary>
        /// 
        /// Save a Visit Request
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to be Saved </param>
        /// <returns> VisitRequestModel </returns>
        Task<ServiceResult<VisitRequestModel>> PostVisitRequestAsync(VisitRequestDto visitRequestData);
    }
}
