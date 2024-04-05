using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IReferenceDataRepository
    {
        Task<ReferenceDataResponseDto> GetAllReferenceDataAsync();
        Task<AddReferenceDataResponseDto> AddTypologyReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<AddReferenceDataResponseDto> AddRealEstateTypeReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<AddReferenceDataResponseDto> AddCityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<AddReferenceDataResponseDto> AddAmenityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
    }
}
