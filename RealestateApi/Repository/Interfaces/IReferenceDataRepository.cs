using RealEstateApi.Dto.Response;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IReferenceDataRepository
    {
        Task<ReferenceDataResponseDto> GetAllReferenceDataAsync();
    }
}
