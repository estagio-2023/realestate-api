using RealEstateApi.Model;

namespace RealEstateApi.Service.Interfaces
{
    public interface IVisitRequestService
    {
        Task<ServiceResult<List<VisitRequestModel>>> GetAllVisistRequestsAsync();
    }
}
