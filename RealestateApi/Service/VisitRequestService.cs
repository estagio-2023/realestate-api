using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Service.Interfaces;
using RealEstateApiLibraryEF.DataAccess;
using RealEstateApiLibraryEF.Entity;

namespace RealEstateApi.Service
{
    public class VisitRequestService: IVisitRequestService
    {
        private readonly RealEstateContext _DbContext;
        private readonly IMapper _mapper;

        public VisitRequestService(RealEstateContext DbContext, IMapper mapper)
        {
            _DbContext = DbContext;
            _mapper = mapper;
  
        }

        /// <summary>
        /// 
        /// Gathers a List of all Visit Requests
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        public async Task<ServiceResult<List<VisitRequestResponseDto>>> GetAllVisitRequestsAsync()
        {
            ServiceResult<List<VisitRequestResponseDto>> response = new();

            try
            {
                var visitRequests = await _DbContext.VisitRequests.ToListAsync();
                var result = _mapper.Map<List<VisitRequestResponseDto>>(visitRequests);

                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add("There was an error while trying to retrieve all visit requests.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gets a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<ServiceResult<VisitRequestResponseDto>> GetVisitRequestByIdAsync(int visitRequestId)
        {
            ServiceResult<VisitRequestResponseDto> response = new();

            try
            {
                var visitRequest = await _DbContext.VisitRequests.FindAsync(visitRequestId);
                var result = _mapper.Map<VisitRequestResponseDto>(visitRequest);

                if (result != null) {
                    response.IsSuccess = true;
                    response.Result = result;
                }
                else
                {
                    response.Result = null;
                    response.AdditionalInformation.Add($"Visit request ID {visitRequestId} was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add($"There was an error while trying to get visit request ID: {visitRequestId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Updates Visit Request confirmation by Visit Request Id
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Visit request Id to update Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<ServiceResult<VisitRequestResponseDto>> UpdateVisitRequestConfirmationByIdAsync(int visitRequestId)
        {
            ServiceResult<VisitRequestResponseDto> response = new();

            try
            {
                var existingVisitRequest = await _DbContext.VisitRequests.FindAsync(visitRequestId);

                if (existingVisitRequest == null)
                {
                    response.AdditionalInformation.Add($"Visit request with ID {visitRequestId} was not found");
                    return response;
                }

                existingVisitRequest.Confirmed = true; 

                await _DbContext.SaveChangesAsync();

                var resultDto = _mapper.Map<VisitRequestResponseDto>(existingVisitRequest);

                response.IsSuccess = true;
                response.Result = resultDto;
            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add($"There was an error while trying to update Visit Request confirmation.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Creates a Visit Request
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to be saved </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<ServiceResult<VisitRequestResponseDto>> AddVisitRequestAsync(VisitRequestDto visitRequestData)
        {
            ServiceResult<VisitRequestResponseDto> response = new();

            try
            {
                var existingRealEstate = await _DbContext.RealEstates.FindAsync(visitRequestData.RealEstateId);
                if (existingRealEstate == null)
                {
                    response.AdditionalInformation.Add($"Real estate ID {visitRequestData.RealEstateId} was not found.");
                    return response;
                }

                var existingAgent = await _DbContext.Agents.FindAsync(visitRequestData.AgentId);
                if (existingAgent == null)
                {
                    response.AdditionalInformation.Add($"Agent ID {visitRequestData.AgentId} was not found.");
                    return response;
                }

                if (!DateOnly.TryParse(visitRequestData.Date, out DateOnly date) ||
                    !TimeSpan.TryParse(visitRequestData.StartTime, out TimeSpan startTime) ||
                    !TimeSpan.TryParse(visitRequestData.EndTime, out TimeSpan endTime))
                {
                    response.AdditionalInformation.Add("Invalid date or time format.");
                    return response;
                }

                var isRealEstateVisitRequestExisting = await _DbContext.VisitRequests
                    .AnyAsync(vr => vr.RealEstateId == visitRequestData.RealEstateId &&
                                    vr.Date == date &&
                                    vr.StartTime == startTime &&
                                    vr.EndTime == endTime);

                if (isRealEstateVisitRequestExisting)
                {
                    response.AdditionalInformation.Add($"There is already a visit request scheduled for this Real estate ID: {visitRequestData.RealEstateId}.");
                    return response;
                }

                var isAgentVisitRequestExisting = await _DbContext.VisitRequests
                    .AnyAsync(vr => vr.AgentId == visitRequestData.AgentId &&
                                    vr.Date == date &&
                                    vr.StartTime == startTime &&
                                    vr.EndTime == endTime);

                if (isAgentVisitRequestExisting)
                {
                    response.AdditionalInformation.Add($"There is already a visit request scheduled for this Agent ID {visitRequestData.AgentId}.");
                    return response;
                }

                var visitRequest = _mapper.Map<VisitRequest>(visitRequestData);
                visitRequest.Date = date;
                visitRequest.StartTime = startTime; 
                visitRequest.EndTime = endTime; 

                _DbContext.VisitRequests.Add(visitRequest);
                await _DbContext.SaveChangesAsync();

                var result = _mapper.Map<VisitRequestResponseDto>(visitRequest);

                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.AdditionalInformation.Add($"There was an error while trying to add Visit Request {visitRequestData.Name}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gathers a List of all Visit Requests
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        public async Task<ServiceResult<List<VisitRequestResponseDto>>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId)
        {
            ServiceResult<List<VisitRequestResponseDto>> response = new();

            try
            {
                var visitRequests = await _DbContext.VisitRequests
                    .Where(vr => vr.RealEstateId == realEstateId)
                    .ToListAsync();

                var result = _mapper.Map<List<VisitRequestResponseDto>>(visitRequests);

                response.Result = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add("There was an error while trying to retrieve all visit requests by realestate id.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// 
        /// Deletes a Visit Request by Id
        /// 
        /// </summary>
        /// <param name="visitRequestId">Id of the Visit Request to delete</param>
        /// <returns>ServiceResult indicating success or failure</returns>
        public async Task<ServiceResult<VisitRequestResponseDto>> DeleteVisitRequestByIdAsync(int visitRequestId)
        {
            ServiceResult<VisitRequestResponseDto> response = new ();

            try
            {
                var existingVisitRequest = await _DbContext.VisitRequests.FindAsync(visitRequestId);

                if (existingVisitRequest == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Visit Request with ID {visitRequestId} was not found.");
                    return response;
                }

                _DbContext.VisitRequests.Remove(existingVisitRequest);
                await _DbContext.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = _mapper.Map<VisitRequestResponseDto>(existingVisitRequest);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete visit request ID: {visitRequestId}.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }


        /// <summary>
        /// 
        /// Get the availability of the visit request based on the parameters
        /// 
        /// </summary>
        /// <param name="visitRequestData">Data containing parameters for visit request</param>
        /// <returns>ServiceResult indicating availability and any additional information</returns>
        public async Task<ServiceResult<VisitRequestAvailabilityDto>> GetVisitRequestAvailabilityAsync(VisitRequestAvailabilityDto visitRequestData)
        {
            ServiceResult<VisitRequestAvailabilityDto> response = new();

            try
            {
                var existingRealEstate = await _DbContext.RealEstates.FindAsync(visitRequestData.RealEstateId);
                if (existingRealEstate == null)
                {
                    response.AdditionalInformation.Add($"Real estate ID {visitRequestData.RealEstateId} was not found.");
                    return response;
                }

                var existingAgent = await _DbContext.Agents.FindAsync(visitRequestData.AgentId);
                if (existingAgent == null)
                {
                    response.AdditionalInformation.Add($"Agent ID {visitRequestData.AgentId} was not found.");
                    return response;
                }

                TimeSpan startTime = TimeSpan.Parse(visitRequestData.StartTime);
                TimeSpan endTime = TimeSpan.Parse(visitRequestData.EndTime);


                var isAgentAvailable = await _DbContext.VisitRequests
                    .AnyAsync(vr => vr.AgentId == visitRequestData.AgentId &&
                                    !(startTime >= vr.EndTime || endTime <= vr.StartTime));

                if (!isAgentAvailable)
                {
                    response.AdditionalInformation.Add($"Agent is not available at this time.");
                    return response;
                }

                var isRealEstateAvailable = await _DbContext.VisitRequests
                    .AnyAsync(vr => vr.RealEstateId == visitRequestData.RealEstateId &&
                                    !(startTime >= vr.EndTime || endTime <= vr.StartTime));

                if (!isRealEstateAvailable)
                {
                    response.AdditionalInformation.Add($"Real Estate is not available at this time.");
                    return response;
                }

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to get visit request availability.");
                response.AdditionalInformation.Add(ex.Message);
            }

            return response;
        }
    }
}