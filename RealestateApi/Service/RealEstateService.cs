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

        public async Task<List<RealEstate>> GetAllRealEstateAsync()
        {
            return await _realEstateRepository.GetAllRealEstateAsync();
        }
        public async Task<RealEstate> AddRealEstateAsync(AddRealEstateRequestDto realEstateData)
        {
            RealEstate response = new();

            if (realEstateData != null)
            {
                response = await _realEstateRepository.AddRealEstateAsync(realEstateData);
            }
            return response;
        }
    }
}
