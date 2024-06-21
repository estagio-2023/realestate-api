using AutoMapper;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApiLibraryEF.Entity;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        /// <summary>
        /// 
        /// Mappers for Agent Service
        /// 
        /// </summary>
        CreateMap<Agent, AgentResponseDto>();

        CreateMap<AgentRequestDto, Agent>();

        /// <summary>
        /// 
        /// Mappers for Customer Service
        /// 
        /// </summary>
        CreateMap<Customer, CustomerResponseDto>();

        CreateMap<CustomerRequestDto, Customer>();
    }
}