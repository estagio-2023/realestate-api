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

        CreateMap<Amenities, ReferenceDataDto>();

        CreateMap<ReferenceDataRequestDto, Amenities>();

        CreateMap<City, ReferenceDataDto>();

        CreateMap<ReferenceDataRequestDto, City>();

        CreateMap<Typology, ReferenceDataDto>();

        CreateMap<ReferenceDataRequestDto, Typology>();

        CreateMap<RealEstateType, ReferenceDataDto>();

        CreateMap<ReferenceDataRequestDto, RealEstateType>();

        /// <summary>
        /// 
        /// Mappers for Visit Requests Service
        /// 
        /// </summary>
        CreateMap<VisitRequest, VisitRequestResponseDto>();

        CreateMap<VisitRequestDto, VisitRequest>()
            .ForMember(dest => dest.Date, opt => opt.Ignore())
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.StartTime)))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.EndTime)));
    }
}