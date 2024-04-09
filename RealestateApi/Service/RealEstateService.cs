using RealEstateApi.Dto.Response;
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

        public async Task<RealEstateResponseDto> GetRealEstateAsync()
        {
            return await _realEstateRepository.GetRealEstateAsync();
        }
    }
}
