using RealEstateApi.Dto.Response;

namespace RealEstateApi.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponseDto> GetAllCustomersAsync();
    }
}
    