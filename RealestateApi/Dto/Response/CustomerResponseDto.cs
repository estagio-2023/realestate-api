using RealEstateApi.Model;

namespace RealEstateApi.Dto.Response
{
    public class CustomerResponseDto
    {
        public List<ClientModel> Customers { get; set; } = new();
    }
}
