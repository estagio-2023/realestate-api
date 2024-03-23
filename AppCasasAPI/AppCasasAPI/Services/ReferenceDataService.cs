using AppCasasAPI.Dto.Response;
using AppCasasAPI.Repository.Interfaces;
using AppCasasAPI.Services.Interface;

namespace AppCasasAPI.Services
{
    public class ReferenceDataService : IReferenceDataService
    {

        private readonly IReferenceDataRepository _referenceDataRepository;

        public ReferenceDataService(IReferenceDataRepository referenceDataRepository)
        {
            _referenceDataRepository = referenceDataRepository;
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