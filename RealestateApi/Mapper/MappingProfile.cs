using AutoMapper;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApiLibraryEF.Entity;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Agent, AgentResponseDto>();
        CreateMap<AgentRequestDto, Agent>();
    }
}