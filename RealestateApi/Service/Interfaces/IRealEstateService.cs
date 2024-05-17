using RealEstateApi.Dto.Request;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IRealEstateService
    {
        /// <summary>
        /// 
        /// Gathers a List of all Real Estate
        /// 
        /// </summary>
        /// <returns> List<RealEstateRequestDto> </returns>
        Task<ServiceResult<List<RealEstateRequestDto>>> GetAllRealEstateAsync();

        /// <summary>
        /// 
        /// Gets a Real Eatate by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get Real Estate </param>
        /// <returns> RealEstateModel </returns>
        Task<ServiceResult<RealEstateModel?>> GetRealEstateByIdAsync(int realEstateId);

        /// <summary>
        /// 
        /// Save a Real Estate
        /// 
        /// </summary>
        /// <param name="realEstateData"> Real Estate Data to be saved </param>
        /// <returns> RealEstateModel </returns>
        Task<ServiceResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateData);        

        /// <summary>
        /// 
        /// Deletes a Real Estate By Id from the Database
        /// 
        /// </summary>
        /// <param name="realEstateId"></param>
        /// <returns></returns>
        Task<ServiceResult<RealEstateModel>> DeleteRealEstateByIdAsync(int realEstateId);
    }
}