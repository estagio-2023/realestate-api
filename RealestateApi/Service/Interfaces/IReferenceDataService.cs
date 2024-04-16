using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;

namespace RealEstateApi.Service.Interfaces
{
    public interface IReferenceDataService
    {
        Task<ReferenceDataResponseDto> GetAllReferenceDataAsync();

        Task<AddReferenceDataResponseDto> AddReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);

        Task<ReferenceDataResponseDto> DeleteReferenceDataAsync(string refDataType, int refDataId);
    }
}
