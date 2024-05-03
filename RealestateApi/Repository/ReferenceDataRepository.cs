using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service;

namespace RealEstateApi.Repository
{
    public class ReferenceDataRepository : IReferenceDataRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public ReferenceDataRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<ServiceResult<ReferenceDataResponseDto>> GetAllReferenceDataAsync()
        {
            ReferenceDataResponseDto refData = new();
            var result = new ServiceResult<ReferenceDataResponseDto>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var typologyQuerry = new NpgsqlCommand("SELECT * FROM typology;", conn);
                using var typologyReader = await typologyQuerry.ExecuteReaderAsync();

                while (typologyReader.Read())
                {
                    var typologyModel = new TypologyModel
                    {
                        Description = typologyReader["description"].ToString(),
                        Id = (int)typologyReader["id"]
                    };
                    refData.Typologies.Add(typologyModel);
                }

                typologyReader.Close();

                using var realEstateTypeQuerry = new NpgsqlCommand("SELECT * FROM realestate_type;", conn);
                var realEstateTypeReader = await realEstateTypeQuerry.ExecuteReaderAsync();

                while (realEstateTypeReader.Read())
                {
                    var realEstateTypeModel = new RealEstateTypeModel
                    {
                        Description = realEstateTypeReader["description"].ToString(),
                        Id = (int)realEstateTypeReader["id"]
                    };
                    refData.RealEstateTypes.Add(realEstateTypeModel);
                }

                realEstateTypeReader.Close();

                using var cityQuerry = new NpgsqlCommand("SELECT * FROM city;", conn);
                var cityReader = await cityQuerry.ExecuteReaderAsync();

                while (cityReader.Read())
                {
                    var citiesModel = new CityModel
                    {
                        Description = cityReader["description"].ToString(),
                        Id = (int)cityReader["id"]
                    };
                    refData.Cities.Add(citiesModel);
                }

                cityReader.Close();

                using var amenitiesQuerry = new NpgsqlCommand("SELECT * FROM amenity;", conn);
                var amenitiesReader = await amenitiesQuerry.ExecuteReaderAsync();

                while (amenitiesReader.Read())
                {
                    var amenitiesModel = new AmenitiesModel
                    {
                        Description = amenitiesReader["description"].ToString(),
                        Id = (int)amenitiesReader["id"]
                    };
                    refData.Amenities.Add(amenitiesModel);
                }

                amenitiesReader.Close();

                result.IsSuccess = true;
                result.Result = refData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.IsSuccess = false;
                result.AdditionalInformation.Add(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<ReferenceDataModel>> AddTypologyReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            ReferenceDataModel response = new();
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var query = new NpgsqlCommand(@"INSERT INTO typology(description) values(@refDataDescription) returning id;", conn);

                query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

                var result = await query.ExecuteScalarAsync();

                response = new ReferenceDataModel
                {
                    Id = (int)result,
                    Description = refData.Description
                };

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> AddRealEstateTypeReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            ReferenceDataModel response = new();
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var query = new NpgsqlCommand(@"INSERT INTO realestate_type(description) values(@refDataDescription) returning id;", conn);

                query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

                var result = await query.ExecuteScalarAsync();

                response = new ReferenceDataModel
                {
                    Id = (int)result,
                    Description = refData.Description
                };

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> AddCityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            ReferenceDataModel response = new();
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var query = new NpgsqlCommand(@"INSERT INTO city(description) values(@refDataDescription) returning id;", conn);

                query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

                var result = await query.ExecuteScalarAsync();

                response = new ReferenceDataModel
                {
                    Id = (int)result,
                    Description = refData.Description
                };

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> AddAmenityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            ReferenceDataModel response = new();
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var query = new NpgsqlCommand(@"INSERT INTO amenity(description) values(@refDataDescription) returning id;", conn);

                query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

                var result = await query.ExecuteScalarAsync();

                response = new ReferenceDataModel
                {
                    Id = (int)result,
                    Description = refData.Description
                };

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> DeleteTypologyReferenceDataAsync(string refDataType, int refDataId)
        {
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var delete = new NpgsqlCommand("DELETE FROM typology WHERE id = @RefDataId", conn);
                delete.Parameters.AddWithValue("@RefDataId", refDataId);

                var response = await GetTypologyReferenceDataAsync(refDataType, refDataId);
                var result = await delete.ExecuteScalarAsync();

                serviceResult.IsSuccess = true;
                serviceResult.Result = response.Result; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }


        public async Task<ServiceResult<ReferenceDataModel>> DeleteRealEstateTypeReferenceDataAsync(string refDataType, int refDataId)
        {
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var delete = new NpgsqlCommand("DELETE FROM realestate_type WHERE id = @RefDataId", conn);
                delete.Parameters.AddWithValue("@RefDataId", refDataId);

                var response = await GetRealEstateReferenceDataAsync(refDataType, refDataId);
                var result = await delete.ExecuteScalarAsync();

                serviceResult.IsSuccess = true;
                serviceResult.Result = response.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> DeleteCityReferenceDataAsync(string refDataType, int refDataId)
        {
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var delete = new NpgsqlCommand("DELETE FROM city WHERE id = @RefDataId", conn);
                delete.Parameters.AddWithValue("@RefDataId", refDataId);

                var response = await GetCityReferenceDataAsync(refDataType, refDataId);
                var result = await delete.ExecuteScalarAsync();

                serviceResult.IsSuccess = true;
                serviceResult.Result = response.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> DeleteAmenityReferenceDataAsync(string refDataType, int refDataId)
        {
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var delete = new NpgsqlCommand("DELETE FROM amenity WHERE id = @RefDataId", conn);
                delete.Parameters.AddWithValue("@RefDataId", refDataId);

                var response = await GetAmenityReferenceDataAsync(refDataType, refDataId);
                var result = await delete.ExecuteScalarAsync();             

                serviceResult.IsSuccess = true;
                serviceResult.Result = response.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> GetTypologyReferenceDataAsync(string refDataType, int refDataId)
        {
            ReferenceDataModel response = new();
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var typologyQuery = new NpgsqlCommand("SELECT * FROM typology WHERE id = @RefDataId;", conn);
                typologyQuery.Parameters.AddWithValue("@RefDataId", refDataId);
                using var typologyReader = await typologyQuery.ExecuteReaderAsync();

                while (typologyReader.Read())
                {
                    response = new ReferenceDataModel
                    {
                        Id = (int)typologyReader["id"],
                        Description = (string)typologyReader["description"],
                    };
                }

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> GetCityReferenceDataAsync(string refDataType, int refDataId)
        {
            ReferenceDataModel response = new();
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var cityQuery = new NpgsqlCommand("SELECT * FROM city WHERE id = @RefDataId;", conn);
                cityQuery.Parameters.AddWithValue("@RefDataId", refDataId);
                using var cityReader = await cityQuery.ExecuteReaderAsync();

                while (cityReader.Read())
                {
                    response = new ReferenceDataModel
                    {
                        Id = (int)cityReader["id"],
                        Description = (string)cityReader["description"],
                    };
                }

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> GetRealEstateReferenceDataAsync(string refDataType, int refDataId)
        {
            ReferenceDataModel response = new();
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var realEstateQuery = new NpgsqlCommand("SELECT * FROM realestate_type WHERE id = @RefDataId;", conn);
                realEstateQuery.Parameters.AddWithValue("@RefDataId", refDataId);
                using var realEstateReader = await realEstateQuery.ExecuteReaderAsync();

                while (realEstateReader.Read())
                {
                    response = new ReferenceDataModel
                    {
                        Id = (int)realEstateReader["id"],
                        Description = (string)realEstateReader["description"],
                    };
                }

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }

        public async Task<ServiceResult<ReferenceDataModel>> GetAmenityReferenceDataAsync(string refDataType, int refDataId)
        {
            ReferenceDataModel response = new();
            var serviceResult = new ServiceResult<ReferenceDataModel>();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var amenityQuery = new NpgsqlCommand("SELECT * FROM amenity WHERE id = @RefDataId;", conn);
                amenityQuery.Parameters.AddWithValue("@RefDataId", refDataId);
                using var amenityReader = await amenityQuery.ExecuteReaderAsync();

                while (amenityReader.Read())
                {
                    response = new ReferenceDataModel
                    {
                        Id = (int)amenityReader["id"],
                        Description = (string)amenityReader["description"],
                    };
                }

                serviceResult.IsSuccess = true;
                serviceResult.Result = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceResult.IsSuccess = false;
                serviceResult.AdditionalInformation.Add(ex.Message);
            }

            return serviceResult;
        }
    }
}