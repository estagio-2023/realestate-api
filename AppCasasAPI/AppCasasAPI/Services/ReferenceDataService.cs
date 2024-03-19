using AppCasasAPI.Dto.Response;
using AppCasasAPI.Services.Interface;

namespace AppCasasAPI.Services
{
    public class ReferenceDataService : IReferenceDataService
    {
        public ReferenceDataService() { }
        public Task<ReferenceDataRequestDto> AddReferenceDataAsync(string refDataType)
        {
            if (!string.IsNullOrWhiteSpace(refDataType))
            {
                switch (refDataType.ToLower())
                {
                    case "typology":

                        

                        break;
                }
            }
        }
    }
}
