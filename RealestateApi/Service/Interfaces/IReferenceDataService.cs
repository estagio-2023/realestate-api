using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IReferenceDataService
    {
        Task<ServiceResult<ReferenceDataResponseDto>> GetAllReferenceDataAsync();

        Task<ReferenceDataModel> AddReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);

        Task<ServiceResult<ReferenceDataResponseDto>> DeleteReferenceDataAsync(string refDataType, int refDataId);

        Task<ServiceResult<ReferenceDataModel>> GetReferenceDataByIdAsync(string refDataType, int refDataId);
    }
}