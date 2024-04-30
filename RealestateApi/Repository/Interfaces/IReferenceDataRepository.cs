﻿using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Service;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IReferenceDataRepository
    {
        Task<ServiceResult<ReferenceDataResponseDto>> GetAllReferenceDataAsync();
        Task<ReferenceDataModel> AddTypologyReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<ReferenceDataModel> AddRealEstateTypeReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<ReferenceDataModel> AddCityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<ReferenceDataModel> AddAmenityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData);
        Task<ServiceResult<ReferenceDataResponseDto>> DeleteTypologyReferenceDataAsync(string refDataType, int refDataId);
        Task<ServiceResult<ReferenceDataResponseDto>> DeleteRealEstateTypeReferenceDataAsync(string refDataType, int refDataId);
        Task<ServiceResult<ReferenceDataResponseDto>> DeleteCityReferenceDataAsync(string refDataType, int refDataId);
        Task<ServiceResult<ReferenceDataResponseDto>> DeleteAmenityReferenceDataAsync(string refDataType, int refDataId);
        Task<ReferenceDataModel> GetTypologyReferenceDataAsync(string refDataType, int refDataId);
        Task<ReferenceDataModel> GetCityReferenceDataAsync(string refDataType, int refDataId);
        Task<ReferenceDataModel> GetRealEstateReferenceDataAsync(string refDataType, int refDataId);
        Task<ReferenceDataModel> GetAmenityReferenceDataAsync(string refDataType, int refDataId);
    }
}