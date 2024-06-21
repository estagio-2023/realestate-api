using AutoMapper;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApiLibraryEF.Entity;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Agent, AgentResponseDto>();
        CreateMap<AgentResponseDto, AgentModel>();
    }
}