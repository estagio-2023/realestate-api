using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;

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
        Task<ServiceResult<List<VisitRequestResponseDto>>> GetAllVisitRequestsAsync();

        /// <summary>
        /// 
        /// Gets a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        Task<ServiceResult<VisitRequestResponseDto?>> GetVisitRequestByIdAsync(int visitRequestId);

        /// <summary>
        /// 
        /// Updates a Visit Request confirmation
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to update a Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        Task<ServiceResult<VisitRequestResponseDto>> UpdateVisitRequestConfirmationByIdAsync(int visitRequestId);

        /// <summary>
        /// 
        /// Gathers a List of all Visit Requests
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        Task<ServiceResult<List<VisitRequestResponseDto>>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId);

        /// <summary>
        /// 
        /// Deletes a Visit Request By Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get a Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        Task<ServiceResult<VisitRequestResponseDto>> DeleteVisitRequestByIdAsync(int visitRequestId);

        /// <summary>
        /// 
        /// Save a Visit Request
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to be Saved </param>
        /// <returns> VisitRequestModel </returns>
        Task<ServiceResult<VisitRequestResponseDto>> AddVisitRequestAsync(VisitRequestDto visitRequestData);

        /// <summary>
        /// 
        /// Get the availability of the visit request based on the parameters
        /// 
        /// </summary>
        /// <param name="visitRequestData"></param>
        /// <returns></returns>
        Task<ServiceResult<VisitRequestAvailabilityDto>> GetVisitRequestAvailabilityAsync(VisitRequestAvailabilityDto visitRequestData);
    }
}
