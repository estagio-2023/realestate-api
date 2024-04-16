using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IReferenceDataService
    {
        Task<ReferenceDataResponseDto> GetAllReferenceDataAsync();

        Task<ReferenceDataModel> AddReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
    }
}
