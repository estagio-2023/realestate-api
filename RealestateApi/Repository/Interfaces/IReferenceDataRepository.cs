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
        Task<ReferenceDataResponseDto> DeleteTypologyReferenceDataAsync(string refDataType, int refDataId);
        Task<ReferenceDataResponseDto> DeleteRealEstateTypeReferenceDataAsync(string refDataType, int refDataId);
        Task<ReferenceDataResponseDto> DeleteCityReferenceDataAsync(string refDataType, int refDataId);
        Task<ReferenceDataResponseDto> DeleteAmenityReferenceDataAsync(string refDataType, int refDataId);
    }
}
