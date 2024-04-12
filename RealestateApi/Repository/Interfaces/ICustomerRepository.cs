using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<ClientModel>> GetAllCustomersAsync();
    }
}
