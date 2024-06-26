namespace RealEstateApi.Dto.Response
{
    public class AgentResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}