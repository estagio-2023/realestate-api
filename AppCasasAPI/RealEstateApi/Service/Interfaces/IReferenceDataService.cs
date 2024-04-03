using RealEstateApi.Dto.Response;

namespace RealEstateApi.Service.Interfaces
{
    public interface IReferenceDataService
    {
        Task<ReferenceDataResponseDto> GetAllReferenceDataAsync();
    }
}
