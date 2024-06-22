namespace RealEstateApi.Dto.Response
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}