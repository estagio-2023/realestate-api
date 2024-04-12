using RealEstateApi.Dto.Response;

namespace RealEstateApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerResponseDto> GetAllCustomersAsync();
    }
}
