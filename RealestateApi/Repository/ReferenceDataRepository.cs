using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;

namespace RealEstateApi.Repository
{
    public class ReferenceDataRepository : IReferenceDataRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public ReferenceDataRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<ReferenceDataResponseDto> GetAllReferenceDataAsync()
        {
            ReferenceDataResponseDto refData = new();
            using var conn = await _dataSource.OpenConnectionAsync();

            using var typologyQuerry = new NpgsqlCommand("SELECT * FROM typology;", conn);
            using var typologyReader = await typologyQuerry.ExecuteReaderAsync();
            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return refData;
        }

        public async Task<ReferenceDataModel> AddTypologyReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO typology(description) values(@refDataDescription) returning id;", conn);

            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            ReferenceDataModel response = new()
            {
                Id = (int)result,
                Description = refData.Description
            };

            return response;
        }

        public async Task<ReferenceDataModel> AddRealEstateTypeReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO realestate_type(description) values(@refDataDescription) returning id;", conn);

            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            ReferenceDataModel response = new()
            {
                Id = (int)result,
                Description = refData.Description
            };

            return response;
        }

        public async Task<ReferenceDataModel> AddCityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO city(description) values(@refDataDescription) returning id;", conn);

            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            ReferenceDataModel response = new()
            {
                Id = (int)result,
                Description = refData.Description
            };

            return response;
        }

        public async Task<ReferenceDataModel> AddAmenityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO amenity(description) values(@refDataDescription) returning id;", conn);

            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            ReferenceDataModel response = new()
            {
                Id = (int)result,
                Description = refData.Description
            };

            return response;
        }        
    }
}
