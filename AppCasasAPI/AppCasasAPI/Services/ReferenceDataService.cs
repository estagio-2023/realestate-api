using AppCasasAPI.Controllers;
using AppCasasAPI.Dto.Response;
using AppCasasAPI.Repository;
using AppCasasAPI.Repository.Interfaces;
using AppCasasAPI.Services.Interface;
using Npgsql;
using System.Data.Common;

namespace AppCasasAPI.Services
{
    public class ReferenceDataService : IReferenceDataService
    {

        private readonly IReferenceDataRepository _referenceDataRepository;

        public ReferenceDataService(IReferenceDataRepository referenceDataRepository)
        {
            _referenceDataRepository = referenceDataRepository;
        }

        public Task<ReferenceDataRequestDto> AddReferenceDataAsync(string refDataType)
        {

            if (!string.IsNullOrWhiteSpace(refDataType))
            {

                switch (refDataType.ToLower())
                {
                    case "typology":

                        _referenceDataRepository.AddReferenceDataAsync(refDataType);

                        break;

                    case "amenity":



                    break;

                    case "realestate_type":



                    break;

                    case "city":



                    break;
                }
            }

            return "Hello";
        }
    }
}
