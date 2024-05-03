using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
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
            return await _realEstateRepository.GetAllRealEstateAsync();
        }

        /// <summary>
        /// 
        /// Creates a Real Estate
        /// 
        /// </summary>
        /// <param name="realEstateDto"> Real Estate Data to be saved </param>
        /// <returns> RealEstateModel </returns>
        public async Task<ServiceResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            return await _realEstateRepository.AddRealEstateAsync(realEstateDto);
        }

        /// <summary>
        /// 
        /// Gets a Real Estate by Id
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to get Real Estate </param>
        /// <returns> RealEstateModel </returns>
        public async Task<ServiceResult<RealEstateModel>> GetRealEstateByIdAsync(int realEstateId)
        {
            return await _realEstateRepository.GetRealEstateByIdAsync(realEstateId);
        }
    }
}