using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class RealEstateService : IRealEstateService
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public RealEstateService(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        /// <summary>
        /// 
        /// Gather a List of all Real Estate
        /// 
        /// </summary>
        /// <returns> List<RealEstateRequestDto> </returns>
        public async Task<ServiceResult<List<RealEstateRequestDto>>> GetAllRealEstateAsync()
        {
            ServiceResult<List<RealEstateRequestDto>> response = new();

            try
            {
                var result = await _realEstateRepository.GetAllRealEstateAsync();

                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add("There was an error while trying to retrieve all real estates.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gets a Real Estate by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get Real Estate </param>
        /// <returns> RealEstateModel </returns>
        public async Task<ServiceResult<RealEstateModel?>> GetRealEstateByIdAsync(int realEstateId)
        {
            ServiceResult<RealEstateModel?> response = new();

            try
            {
                var result = await _realEstateRepository.GetRealEstateByIdAsync(realEstateId);

                if (result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Real Estate ID {realEstateId} was not found.");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to get real estate ID: {realEstateId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Creates a Real Estate
        /// 
        /// </summary>
        /// <param name="realEstateDto"> Real Estate Data to be saved </param>
        /// <returns> RealEstateModel </returns>
        public async Task<ServiceResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateData)
        {
            ServiceResult<RealEstateModel> response = new();

            try
            {
                var result = await _realEstateRepository.AddRealEstateAsync(realEstateData);

                if (result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to add real estate {realEstateData.Title}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Deletes a Real Estate by Id
        /// 
        /// </summary>
        /// <param name="realEstateId">Id to get Real Estate</param>
        /// <returns> RealEstateModel </returns>
        public async Task<ServiceResult<RealEstateModel>> DeleteRealEstateByIdAsync(int realEstateId)
        {
            ServiceResult<RealEstateModel> response = new();

            try
            {
                var existingRealEstate = await _realEstateRepository.GetRealEstateByIdAsync(realEstateId);

                if (existingRealEstate == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Real Estate ID {realEstateId} was not found");
                    return response;
                }

                var result = await _realEstateRepository.DeleteRealEstateByIdAsync(realEstateId);

                if (result)
                {
                    response.IsSuccess = true;
                    response.Result = existingRealEstate;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete real estate ID: {realEstateId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }
    }
}