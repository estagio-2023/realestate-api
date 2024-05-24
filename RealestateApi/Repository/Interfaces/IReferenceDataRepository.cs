using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;

namespace RealEstateApi.Repository.Interfaces
{
    public interface IReferenceDataRepository
    {
        /// <summary>
        /// 
        /// Gather a List of all Reference Data
        /// 
        /// </summary>
        /// <returns> ReferenceDataResponseDto </returns>
        Task<ReferenceDataResponseDto> GetAllReferenceDataAsync();

        /// <summary>
        /// 
        /// Gets a Typology by Id
        /// 
        /// </summary>
        /// <param name="refDataId"> Id to get a Typology </param>
        /// <returns> ReferenceDataModel </returns>
        Task<ReferenceDataModel?> GetTypologyReferenceDataAsync(int refDataId);

        /// <summary>
        /// 
        /// Gets a City by Id
        /// 
        /// </summary>
        /// <param name="refDataId"> Id to get a City </param>
        /// <returns> ReferenceDataModel </returns>
        Task<ReferenceDataModel?> GetCityReferenceDataAsync(int refDataId);

        /// <summary>
        /// 
        /// Gets a Real Estate Type by Id
        /// 
        /// </summary>
        /// <param name="refDataId"> Id to get a Real Estate Type </param>
        /// <returns> ReferenceDataModel </returns>
        Task<ReferenceDataModel?> GetRealEstateReferenceDataAsync(int refDataId);

        /// <summary>
        /// 
        /// Gets a Amenity by Id
        /// 
        /// </summary>
        /// <param name="refDataId"> Id to get a Amenity </param>
        /// <returns> ReferenceDataModel </returns>
        Task<ReferenceDataModel?> GetAmenityReferenceDataAsync(int refDataId);

        /// <summary>
        /// 
        /// Save a Typology
        /// 
        /// </summary>
        /// <param name="refData"> Data to be saved </param>
        /// <returns> ReferenceDataModel </returns>
        Task<ReferenceDataModel?> AddTypologyReferenceDataAsync(ReferenceDataRequestDto refData);

        /// <summary>
        /// 
        /// Save a Real Estate Type
        /// 
        /// </summary>
        /// <param name="refData"> Data to be saved </param>
        /// <returns> ReferenceDataModel </returns>
        Task<ReferenceDataModel?> AddRealEstateTypeReferenceDataAsync(ReferenceDataRequestDto refData);

        /// <summary>
        /// 
        /// Save a City
        /// 
        /// </summary>
        /// <param name="refData"> Data to be saved </param>
        /// <returns> ReferenceDataModel </returns>
        Task<ReferenceDataModel?> AddCityReferenceDataAsync(ReferenceDataRequestDto refData);

        /// <summary>
        /// 
        /// Save an Amenity
        /// 
        /// </summary>
        /// <param name="refData"> Data to be saved</param>
        /// <returns> ReferenceDataModel </returns>
        Task<ReferenceDataModel?> AddAmenityReferenceDataAsync(ReferenceDataRequestDto refData);

        /// <summary>
        /// 
        /// Deletes a Typology By Id
        /// 
        /// </summary>
        /// <param name="refDataId"> Id to delete a Typolgy </param>
        /// <returns> ReferenceDataModel </returns>
        Task<bool> DeleteTypologyReferenceDataAsync(int refDataId);

        /// <summary>
        /// 
        /// Deletes a Real Estate Type By Id
        /// 
        /// </summary>
        /// <param name="refDataId"> Id to delete a RealEstate Type </param>
        /// <returns> ReferenceDataModel </returns>
        Task<bool> DeleteRealEstateTypeReferenceDataAsync(int refDataId);

        /// <summary>
        /// 
        /// Deletes a City By Id
        /// 
        /// </summary>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        Task<bool> DeleteCityReferenceDataAsync(int refDataId);

        /// <summary>
        /// 
        /// Deletes a Amenity By Id
        /// 
        /// </summary>
        /// <param name="refDataId"> Id to delete a Amenity </param>
        /// <returns> ReferenceDataModel </returns>
        Task<bool> DeleteAmenityReferenceDataAsync(int refDataId);
    }
}