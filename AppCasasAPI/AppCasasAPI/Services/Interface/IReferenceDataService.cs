using AppCasasAPI.Dto.Response;

namespace AppCasasAPI.Services.Interface
{
    public interface IReferenceDataService
    {
        public Task<ReferenceDataRequestDto> AddReferenceDataAsync(string refDataType);
    }
}
