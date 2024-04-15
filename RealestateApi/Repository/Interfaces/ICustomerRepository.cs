using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<ClientModel>> GetAllCustomersAsync();
        Task<AddCustomDtoResponse> AddCustomersAsync(CustomDtoRequest customerData);
    }
}