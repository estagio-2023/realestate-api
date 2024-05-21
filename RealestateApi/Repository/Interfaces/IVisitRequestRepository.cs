using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IVisitRequestRepository
    {
        Task<List<VisitRequestModel>> GetAllVisistRequestsAsync();
    }
}
