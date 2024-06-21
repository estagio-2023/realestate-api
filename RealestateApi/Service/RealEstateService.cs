using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Dto.Request;
using RealEstateApi.Service.Interfaces;
using RealEstateApiLibraryEF.DataAccess;
using RealEstateApiLibraryEF.Entity;
using RealEstateApi.Dto.Response;

namespace RealEstateApi.Service
{
    public class RealEstateService : IRealEstateService
    {
        private readonly RealEstateContext _DbContext;
        private readonly IMapper _mapper;

        public RealEstateService(RealEstateContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<RealEstateResponseDto>>> GetAllRealEstateAsync()
        {
            ServiceResult<List<RealEstateResponseDto>> response = new();

            try
            {
                var realEstates = await _DbContext.RealEstates.ToListAsync();
                var result = _mapper.Map<List<RealEstateResponseDto>>(realEstates);

                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add("There was an error while trying to retrieve all real estates.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        public async Task<ServiceResult<RealEstateResponseDto>> GetRealEstateByIdAsync(int realEstateId)
        {
            ServiceResult<RealEstateResponseDto?> response = new();

            try
            {
                var realEstate = await _DbContext.RealEstates.FindAsync(realEstateId);
                var result = _mapper.Map<RealEstateResponseDto>(realEstate);

                if (result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Real Estate ID {realEstateId} was not found.");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to get real estate ID: {realEstateId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        public async Task<ServiceResult<RealEstateResponseDto>> AddRealEstateAsync(AddRealEstateRequestDto realEstateData)
        {
            ServiceResult<RealEstateResponseDto> response = new();

            try
            {
                var existingRealEstateType = await _DbContext.RealEstateTypes.FindAsync(realEstateData.RealEstateTypeId);
                if (existingRealEstateType == null)
                {
                    response.AdditionalInformation.Add($"Real estate type ID {realEstateData.RealEstateTypeId} was not found.");
                    return response;
                }

                var existingCity = await _DbContext.Cities.FindAsync(realEstateData.CityId);
                if (existingCity == null)
                {
                    response.AdditionalInformation.Add($"City ID {realEstateData.CityId} was not found.");
                    return response;
                }

                var existingTypology = await _DbContext.Typologies.FindAsync(realEstateData.TypologyId);
                if (existingTypology == null)
                {
                    response.AdditionalInformation.Add($"Typology ID {realEstateData.TypologyId} was not found.");
                    return response;
                }

                var existingCustomer = await _DbContext.Customers.FindAsync(realEstateData.CustomerId);
                if (existingCustomer == null)
                {
                    response.AdditionalInformation.Add($"Customer ID {realEstateData.CustomerId} was not found.");
                    return response;
                }

                var realEstate = _mapper.Map<RealEstate>(realEstateData);
                var addedRealEstate = await _DbContext.RealEstates.AddAsync(realEstate);
                await _DbContext.SaveChangesAsync();

                var result = _mapper.Map<RealEstateResponseDto>(addedRealEstate.Entity);
                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to add real estate {realEstateData.Title}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        public async Task<ServiceResult<RealEstateResponseDto>> DeleteRealEstateByIdAsync(int realEstateId)
        {
            ServiceResult<RealEstateResponseDto> response = new();

            try
            {
                var existingRealEstate = await _DbContext.RealEstates.FindAsync(realEstateId);

                if (existingRealEstate == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Real Estate ID {realEstateId} was not found");
                    return response;
                }

                _DbContext.RealEstates.Remove(existingRealEstate);
                await _DbContext.SaveChangesAsync();

                var result = _mapper.Map<RealEstateResponseDto>(existingRealEstate);
                response.IsSuccess = true;
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete real estate ID: {realEstateId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }
    }
}