using RealEstateApi.Dto.Request;
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
        /// <param name="realEstateDto"> Real Estate Data to be Saved </param>
        /// <returns> RealEstateModel </returns>
        Task<ServiceResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto);

        /// <summary>
        /// 
        /// Gets a Real Estates by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get Real Estate </param>
        /// <returns> RealEstateModel </returns>
        Task<ServiceResult<RealEstateModel>> GetRealEstateByIdAsync(int realEstateId);

        /// <summary>
        /// 
        /// Gets a real estate by customer Id
        /// 
        /// </summary>
        /// <returns> RealEstateRequestDto </returns>
        Task<RealEstateModel?> GetRealEstateByCustomerIdAsync(int customerId);

        /// <summary>
        /// 
        /// Gets a real estate by agent Id
        /// 
        /// </summary>
        /// <returns> RealEstateRequestDto </returns>
        Task<RealEstateModel?> GetRealEstateByAgentIdAsync(int agentId);

        /// <summary>
        /// 
        /// Deletes a real estate by Id from the data base
        /// 
        /// </summary>
        /// <param name="realEstateId"></param>
        /// <returns></returns>
        Task<ServiceResult<RealEstateModel>> DeleteRealEstateByIdAsync(int realEstateId);
    }
}