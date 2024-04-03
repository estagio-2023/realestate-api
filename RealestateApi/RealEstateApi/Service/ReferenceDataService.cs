using RealEstateApi.Dto.Response;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IReferenceDataRepository _referenceDataRepostory;

        public ReferenceDataService(IReferenceDataRepository referenceDataRepostory)
        {
            _referenceDataRepostory = referenceDataRepostory;
        }

        public async Task<ReferenceDataResponseDto> GetAllReferenceDataAsync()
        {
            return await _referenceDataRepostory.GetAllReferenceDataAsync();
        }        
    }
}
