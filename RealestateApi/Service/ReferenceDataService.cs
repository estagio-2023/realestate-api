using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Service.Interfaces;
using RealEstateApiLibraryEF.DataAccess;
using RealEstateApiLibraryEF.Entity;

namespace RealEstateApi.Service
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly RealEstateContext _dbContext;
        private readonly IMapper _mapper;

        public ReferenceDataService(RealEstateContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ReferenceDataResponseDto>> GetAllReferenceDataAsync()
        {
            ServiceResult<ReferenceDataResponseDto> response = new();

            try
            {
                var amenities = await _dbContext.Amenities.ToListAsync();
                var cities = await _dbContext.Cities.ToListAsync();
                var typologies = await _dbContext.Typologies.ToListAsync();
                var realEstateTypes = await _dbContext.RealEstateTypes.ToListAsync();

                var referenceDataResponseDto = new ReferenceDataResponseDto
                {
                    Amenities = _mapper.Map<List<ReferenceDataDto>>(amenities),
                    Cities = _mapper.Map<List<ReferenceDataDto>>(cities),
                    Typologies = _mapper.Map<List<ReferenceDataDto>>(typologies),
                    RealEstateTypes = _mapper.Map<List<ReferenceDataDto>>(realEstateTypes)
                };

                response.Result = referenceDataResponseDto;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add("There was an error while trying to retrieve all reference data.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        public async Task<ServiceResult<ReferenceDataResponseDto>> GetReferenceDataByIdAsync(string refDataType, int refDataId)
        {
            ServiceResult<ReferenceDataResponseDto> response = new();

            try
            {
                ReferenceDataResponseDto result = new ReferenceDataResponseDto();

                switch (refDataType.ToLower())
                {
                    case "amenity":
                        var amenity = await _dbContext.Amenities.FindAsync(refDataId);
                        result.Amenities = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(amenity) };
                        break;

                    case "city":
                        var city = await _dbContext.Cities.FindAsync(refDataId);
                        result.Cities = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(city) };
                        break;

                    case "typology":
                        var typology = await _dbContext.Typologies.FindAsync(refDataId);
                        result.Typologies = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(typology) };
                        break;

                    case "realestate_type":
                        var realEstateType = await _dbContext.RealEstateTypes.FindAsync(refDataId);
                        result.RealEstateTypes = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(realEstateType) };
                        break;

                    default:
                        response.IsSuccess = false;
                        response.AdditionalInformation.Add($"Invalid reference data type: {refDataType}");
                        return response;
                }

                if (result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Reference data type {refDataType} with ID {refDataId} was not found.");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to get reference data type: {refDataType} ID: {refDataId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        public async Task<ServiceResult<ReferenceDataResponseDto>> AddReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            ServiceResult<ReferenceDataResponseDto> response = new();

            try
            {
                switch (refDataType.ToLower())
                {
                    case "amenity":
                        var amenityToAdd = _mapper.Map<Amenities>(refData);
                        var addedAmenity = await _dbContext.Amenities.AddAsync(amenityToAdd);
                        await _dbContext.SaveChangesAsync();
                        response.Result = new ReferenceDataResponseDto { Amenities = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(addedAmenity.Entity) } };
                        break;

                    case "city":
                        var cityToAdd = _mapper.Map<City>(refData);
                        var addedCity = await _dbContext.Cities.AddAsync(cityToAdd);
                        await _dbContext.SaveChangesAsync();
                        response.Result = new ReferenceDataResponseDto { Cities = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(addedCity.Entity) } };
                        break;

                    case "typology":
                        var typologyToAdd = _mapper.Map<Typology>(refData);
                        var addedTypology = await _dbContext.Typologies.AddAsync(typologyToAdd);
                        await _dbContext.SaveChangesAsync();
                        response.Result = new ReferenceDataResponseDto { Typologies = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(addedTypology.Entity) } };
                        break;

                    case "realestate_type":
                        var realEstateTypeToAdd = _mapper.Map<RealEstateType>(refData);
                        var addedRealEstateType = await _dbContext.RealEstateTypes.AddAsync(realEstateTypeToAdd);
                        await _dbContext.SaveChangesAsync();
                        response.Result = new ReferenceDataResponseDto { RealEstateTypes = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(addedRealEstateType.Entity) } };
                        break;

                    default:
                        response.IsSuccess = false;
                        response.AdditionalInformation.Add($"Invalid reference data type: {refDataType}");
                        return response;
                }

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to add reference data of type {refDataType}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }


        public async Task<ServiceResult<ReferenceDataResponseDto>> DeleteReferenceDataAsync(string refDataType, int refDataId)
        {
            ServiceResult<ReferenceDataResponseDto> response = new();

            try
            {
                switch (refDataType.ToLower())
                {
                    case "amenity":
                        var amenityToDelete = await _dbContext.Amenities.FindAsync(refDataId);
                        if (amenityToDelete != null)
                        {
                            _dbContext.Amenities.Remove(amenityToDelete);
                            await _dbContext.SaveChangesAsync();
                            response.Result = new ReferenceDataResponseDto { Amenities = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(amenityToDelete) } };
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.AdditionalInformation.Add($"Amenity with ID {refDataId} was not found.");
                            return response;
                        }
                        break;

                    case "city":
                        var cityToDelete = await _dbContext.Cities.FindAsync(refDataId);
                        if (cityToDelete != null)
                        {
                            _dbContext.Cities.Remove(cityToDelete);
                            await _dbContext.SaveChangesAsync();
                            response.Result = new ReferenceDataResponseDto { Cities = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(cityToDelete) } };
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.AdditionalInformation.Add($"City with ID {refDataId} was not found.");
                            return response;
                        }
                        break;

                    case "typology":
                        var typologyToDelete = await _dbContext.Typologies.FindAsync(refDataId);
                        if (typologyToDelete != null)
                        {
                            _dbContext.Typologies.Remove(typologyToDelete);
                            await _dbContext.SaveChangesAsync();
                            response.Result = new ReferenceDataResponseDto { Typologies = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(typologyToDelete) } };
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.AdditionalInformation.Add($"Typology with ID {refDataId} was not found.");
                            return response;
                        }
                        break;

                    case "realestate_type":
                        var realEstateTypeToDelete = await _dbContext.RealEstateTypes.FindAsync(refDataId);
                        if (realEstateTypeToDelete != null)
                        {
                            _dbContext.RealEstateTypes.Remove(realEstateTypeToDelete);
                            await _dbContext.SaveChangesAsync();
                            response.Result = new ReferenceDataResponseDto { RealEstateTypes = new List<ReferenceDataDto> { _mapper.Map<ReferenceDataDto>(realEstateTypeToDelete) } };
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.AdditionalInformation.Add($"Real Estate Type with ID {refDataId} was not found.");
                            return response;
                        }
                        break;

                    default:
                        response.IsSuccess = false;
                        response.AdditionalInformation.Add($"Invalid reference data type: {refDataType}");
                        return response;
                }

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete reference data of type {refDataType} with ID {refDataId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }
    }
}
