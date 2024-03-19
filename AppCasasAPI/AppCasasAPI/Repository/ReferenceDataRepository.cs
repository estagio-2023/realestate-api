using AppCasasAPI.Dto.Response;
using AppCasasAPI.Model;
using AppCasasAPI.Repository.Interfaces;
using Npgsql;

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
                    var typologyModel = new TypologyModel();
                    typologyModel.Description = typologyReader["description"].ToString();
                    typologyModel.Id = (int)typologyReader["id"];
                    refData.TypologiesList.Add(typologyModel);
                }
                typologyReader.Close();

                using var realEstateTypeQuerry = new NpgsqlCommand("SELECT * FROM realestate_type;", conn);
                var realEstateTypeReader = await realEstateTypeQuerry.ExecuteReaderAsync();

                while (realEstateTypeReader.Read())
                {
                    var realEstateTypeModel = new RealEstateTypeModel();
                    realEstateTypeModel.Description = realEstateTypeReader["description"].ToString();
                    realEstateTypeModel.Id = (int)realEstateTypeReader["id"];
                    refData.RealEstateTypesList.Add(realEstateTypeModel);
                }

                realEstateTypeReader.Close();

                using var cityQuerry = new NpgsqlCommand("SELECT * FROM city;", conn);
                var cityReader = await cityQuerry.ExecuteReaderAsync();

                while (cityReader.Read())
                {
                    var citiesModel = new CityModel();
                    citiesModel.Description = cityReader["description"].ToString();
                    citiesModel.Id = (int)cityReader["id"];
                    refData.CitiesList.Add(citiesModel);
                }

                cityReader.Close();

                using var amenitiesQuerry = new NpgsqlCommand("SELECT * FROM amenity;", conn);
                var amenitiesReader = await cityQuerry.ExecuteReaderAsync();

                while (amenitiesReader.Read())
                {
                    var amenitiesModel = new AmenitiesModel();
                    amenitiesModel.Description = amenitiesReader["description"].ToString();
                    amenitiesModel.Id = (int)amenitiesReader["id"];
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
    }
}
