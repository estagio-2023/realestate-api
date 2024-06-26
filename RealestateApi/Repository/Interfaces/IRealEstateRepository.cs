﻿using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Service;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IRealEstateRepository
    {
        /// <summary>
        /// 
        /// Gather a List of all Real Estate
        /// 
        /// </summary>
        /// <returns> List<RealEstateRequestDto> </returns>
        Task<List<RealEstateRequestDto>> GetAllRealEstateAsync();

        /// <summary>
        /// 
        /// Gets a Real Estates by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get Real Estate </param>
        /// <returns> RealEstateModel </returns>
        Task<RealEstateModel?> GetRealEstateByIdAsync(int realEstateId);

        /// <summary>
        /// 
        /// Save a Real Estate
        /// 
        /// </summary>
        /// <param name="realEstateDto"> Real Estate Data to be Saved </param>
        /// <returns> RealEstateModel </returns>
        Task<RealEstateModel?> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto);

        /// <summary>
        /// 
        /// Gets a real estate by customer Id
        /// 
        /// </summary>
        /// <returns> RealEstateRequestDto </returns>
        Task<RealEstateModel?> GetRealEstateByCustomerIdAsync(int customerId);

        /// <summary>
        /// 
        /// Deletes a real estate by Id from the data base
        /// 
        /// </summary>
        /// <param name="realEstateId"></param>
        /// <returns></returns>
        Task<bool> DeleteRealEstateByIdAsync(int realEstateId);
    }
}