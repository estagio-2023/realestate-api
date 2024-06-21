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

        /// <summary>
        /// 
        /// Mappers for Real Estate Service
        /// 
        /// </summary>
        CreateMap<RealEstate, RealEstateResponseDto>();

        CreateMap<AddRealEstateRequestDto, RealEstate>();

        /// <summary>
        /// 
        /// Mappers for Reference DataService
        /// 
        /// </summary>
        CreateMap<ReferenceData, ReferenceDataDto>();

        CreateMap<ReferenceDataRequestDto, RealEstate>();

        /// <summary>
        /// 
        /// Mappers for Visit Requests Service
        /// 
        /// </summary>
        CreateMap<VisitRequest, VisitRequestResponseDto>();

        CreateMap<VisitRequestDto, VisitRequest>();
    }
}