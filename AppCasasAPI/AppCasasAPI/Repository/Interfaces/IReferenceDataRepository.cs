using AppCasasAPI.Dto.Response;

namespace AppCasasAPI.Repository.Interfaces
{
    public interface IReferenceDataRepository
    {
        Task<ReferenceDataResponseDto> GetAllReferenceDataAsync();
    }
}