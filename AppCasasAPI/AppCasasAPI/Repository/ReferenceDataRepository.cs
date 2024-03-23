using AppCasasAPI.Dto.Response;
using AppCasasAPI.Model;
using AppCasasAPI.Repository.Interfaces;
using Npgsql;
using NpgsqlTypes;

namespace AppCasasAPI.Repository
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
                    refData.TypologiesList.Add(typologyModel);
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
                    refData.RealEstateTypesList.Add(realEstateTypeModel);
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
                    refData.CitiesList.Add(citiesModel);
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
                    refData.AmenitiesList.Add(amenitiesModel);
                }

                amenitiesReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return refData;
        }

        async Task<ReferenceDataRequestDto> AddReferenceDataAsync(string refDataType, string refDataValue)
        {
            ReferenceDataRequestDto refData = new();
            using var conn = await _dataSource.OpenConnectionAsync();

            using var querry = new NpgsqlCommand(@"INSERT INTO (@refDataType) values(@refDataValue)", conn)
            {
                Parameters = { refDataType, refDataValue }
            };

            return refData;

        }
    
        public async Task<string?> GetUserName()
        {
            using (var conn = await _dataSource.OpenConnectionAsync())
            {
                using var command = new NpgsqlCommand("SELECT nome FROM agent;", conn);
                var execute = await command.ExecuteScalarAsync();
                if (execute != null)
                {
                    return execute.ToString();
                }

                return null;
            }
        }

        public async Task<AddReferenceDataResponseDto> AddTypologyReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO typology(description) values(@refDataDescription) returning id;", conn);

            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            AddReferenceDataResponseDto response = new()
            {
                Id = (int)result,
                Description = refData.Description
            };

            return response;
        }

        public async Task<AddReferenceDataResponseDto> AddRealEstateTypeReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO realestate_type(description) values(@refDataDescription) returning id;", conn);

            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            AddReferenceDataResponseDto response = new()
            {
                Id = (int)result,
                Description = refData.Description
            };

            return response;
        }

        public async Task<AddReferenceDataResponseDto> AddCityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO city(description) values(@refDataDescription) returning id;", conn);

            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            AddReferenceDataResponseDto response = new()
            {
                Id = (int)result,
                Description = refData.Description
            };

            return response;
        }

        public async Task<AddReferenceDataResponseDto> AddAmenityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO amenity(description) values(@refDataDescription) returning id;", conn);

            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            AddReferenceDataResponseDto response = new()
            {
                Id = (int)result,
                Description = refData.Description
            };

            return response;
        }
    }
}
