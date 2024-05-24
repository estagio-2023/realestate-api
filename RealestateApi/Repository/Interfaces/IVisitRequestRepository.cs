﻿using RealEstateApi.Model;

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
        /// Gathers a List of All Visit Requests by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id of fk_realestate_id </param>
        /// <returns> List<VisitRequestModel> </returns>
        Task<List<VisitRequestModel>> GetAllVisitRequestsByIdAsync(int realEstateId);
    }
}
