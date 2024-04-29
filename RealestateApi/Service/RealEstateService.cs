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

        public async Task<ServiceResult<List<RealEstateRequestDto>>> GetAllRealEstateAsync()
        {
            return await _realEstateRepository.GetAllRealEstateAsync();
        }

        public async Task<ServiceResult<RealEstateModel>> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            return await _realEstateRepository.AddRealEstateAsync(realEstateDto);
        }
    }
}