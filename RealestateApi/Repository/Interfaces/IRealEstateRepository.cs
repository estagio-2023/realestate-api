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
        Task<ServiceResult<List<RealEstateRequestDto>>> GetAllRealEstateAsync();

        /// <summary>
        /// 
        /// Save a Real Estate
        /// 
        /// </summary>
        /// <param name="realEstateDto"> Real estate data to be saved </param>
        /// <returns> RealEstateModel </returns>
        Task<ServiceResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto);

        /// <summary>
        /// 
        /// Gathers Real Eatates by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get real estate </param>
        /// <returns> RealEstateModel </returns>
        Task<ServiceResult<RealEstateModel>> GetRealEstateByIdAsync(int realEstateId);
    }
}