using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IReferenceDataRepository
    {
        Task<ReferenceDataResponseDto> GetAllReferenceDataAsync();
        Task<ReferenceDataModel> AddTypologyReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<ReferenceDataModel> AddRealEstateTypeReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<ReferenceDataModel> AddCityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<ReferenceDataModel> AddAmenityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
    }
}
