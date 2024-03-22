using AppCasasAPI.Dto.Response;

namespace AppCasasAPI.Services.Interface
{
    public interface IReferenceDataService
    {
        public Task<AddReferenceDataResponseDto> AddReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
    }
}