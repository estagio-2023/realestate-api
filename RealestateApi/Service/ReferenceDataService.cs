using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IReferenceDataRepository _referenceDataRepository;

        public ReferenceDataService(IReferenceDataRepository referenceDataRepository)
        {
            _referenceDataRepository = referenceDataRepository;
        }

        public async Task<ReferenceDataResponseDto> GetAllReferenceDataAsync()
        {
            return await _referenceDataRepository.GetAllReferenceDataAsync();
        }

        public async Task<AddReferenceDataResponseDto> AddReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            AddReferenceDataResponseDto response = new();

            if (!string.IsNullOrWhiteSpace(refDataType))
            {
                switch (refDataType.ToLower())
                {
                    case "typology":
                        response = await _referenceDataRepository.AddTypologyReferenceDataAsync(refDataType, refData);
                        break;

                    case "amenity":
                        response = await _referenceDataRepository.AddAmenityReferenceDataAsync(refDataType, refData);
                        break;

                    case "realestate_type":
                        response = await _referenceDataRepository.AddRealEstateTypeReferenceDataAsync(refDataType, refData);
                        break;

                    case "city":
                        response = await _referenceDataRepository.AddCityReferenceDataAsync(refDataType, refData);
                        break;
                }
            }
            return response;
        }     
    }
}
