using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IReferenceDataRepository _referenceDataRepository;

        public ReferenceDataService(IReferenceDataRepository referenceDataRepository)
        {
            _referenceDataRepository = referenceDataRepository;
        }

        //// <summary>
        /// 
        /// Gather a List of all Reference Data
        /// 
        /// </summary>
        /// <returns> ReferenceDataResponseDto </returns>
        public async Task<ServiceResult<ReferenceDataResponseDto>> GetAllReferenceDataAsync()
        {
            ServiceResult<ReferenceDataResponseDto> response = new();

            try
            {
                var result = await _referenceDataRepository.GetAllReferenceDataAsync();

                response.Result = result;
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

        /// <summary>
        /// 
        /// Gets a Reference Data by Id
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to get Reference Data </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ServiceResult<ReferenceDataModel>> GetReferenceDataByIdAsync(string refDataType, int refDataId)
        {
            ServiceResult<ReferenceDataModel> response = new();
            ReferenceDataModel? result = new();

            try
            {
                switch (refDataType.ToLower())
                {
                    case "typology":
                        result = await _referenceDataRepository.GetTypologyReferenceDataAsync(refDataId);
                        break;

                    case "city":
                        result = await _referenceDataRepository.GetCityReferenceDataAsync(refDataId);
                        break;

                    case "realestate_type":
                        result = await _referenceDataRepository.GetRealEstateReferenceDataAsync(refDataId);
                        break;

                    case "amenity":
                        result = await _referenceDataRepository.GetAmenityReferenceDataAsync(refDataId);
                        break;
                }

                if(result != null)
                {
                    response.Result = result;
                    response.IsSuccess = true;
                }
                else
                {
                    response.AdditionalInformation.Add($"Reference data type {refDataType} reference data id {refDataId} was not found");
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

        /// <summary>
        /// 
        /// Creates a Reference Data
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refData"> Data to be saved </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ServiceResult<ReferenceDataModel>> AddReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            ServiceResult<ReferenceDataModel> response = new();

            ReferenceDataModel? referenceDataResult = new();

            try
            {
                if (!string.IsNullOrWhiteSpace(refDataType))
                {
                    switch (refDataType.ToLower())
                    {
                        case "typology":
                            referenceDataResult = await _referenceDataRepository.AddTypologyReferenceDataAsync(refData);
                            break;

                        case "amenity":
                            referenceDataResult = await _referenceDataRepository.AddAmenityReferenceDataAsync(refData);
                            break;

                        case "realestate_type":
                            referenceDataResult = await _referenceDataRepository.AddRealEstateTypeReferenceDataAsync(refData);
                            break;

                        case "city":
                            referenceDataResult = await _referenceDataRepository.AddCityReferenceDataAsync(refData);
                            break;
                    }

                    if(referenceDataResult != null)
                    {
                        response.Result = referenceDataResult;
                        response.IsSuccess = true;
                    }
                    else
                    {
                        response.AdditionalInformation.Add($"There was an error while trying to add reference data of type {refDataType} and description {refData.Description}.");
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to add reference data of type {refDataType} and description {refData.Description}.");
                response.AdditionalInformation.Add(ex.Message);
            }            
            
            return response;
        }

        /// <summary>
        /// 
        /// Delete Reference Data
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a Reference Data </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ServiceResult<ReferenceDataModel>> DeleteReferenceDataAsync(string refDataType, int refDataId)
        {
            ServiceResult<ReferenceDataModel> response = new();

            try
            {
                var existingReferenceData = await GetReferenceDataByIdAsync(refDataType, refDataId);

                if (existingReferenceData.Result == null)
                {
                    response.IsSuccess = false;
                    response.AdditionalInformation.Add($"Reference Data Type: {refDataType} ID: {refDataId} was not found");
                    return response;
                }

                var deleteResult = false;

                switch (refDataType.ToLower())
                {
                    case "typology":
                        deleteResult = await _referenceDataRepository.DeleteTypologyReferenceDataAsync(refDataId);

                        if (deleteResult)
                        {
                            response.Result = existingReferenceData.Result;
                            response.IsSuccess = true;
                        }

                        break;

                    case "realestate_type":
                        deleteResult = await _referenceDataRepository.DeleteRealEstateTypeReferenceDataAsync(refDataId);

                        if (deleteResult)
                        {
                            response.Result = existingReferenceData.Result;
                            response.IsSuccess = true;
                        }

                        break;

                    case "city":
                        deleteResult = await _referenceDataRepository.DeleteCityReferenceDataAsync(refDataId);

                        if (deleteResult)
                        {
                            response.Result = existingReferenceData.Result;
                            response.IsSuccess = true;
                        }

                        break;

                    case "amenity":
                        deleteResult = await _referenceDataRepository.DeleteAmenityReferenceDataAsync(refDataId);

                        if (deleteResult)
                        {
                            response.Result = existingReferenceData.Result;
                            response.IsSuccess = true;
                        }

                        break;
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.AdditionalInformation.Add($"There was an error while trying to delete agent reference data type: {refDataType} ID: {refDataId}.");
                response.AdditionalInformation.Add(ex.Message);
            }            

            return response;
        }        
    }
}