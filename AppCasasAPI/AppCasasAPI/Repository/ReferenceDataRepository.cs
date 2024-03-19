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
            using (var conn = await _dataSource.OpenConnectionAsync())
            {
                using var typologyQuerry = new NpgsqlCommand("SELECT * FROM tipologia;", conn);
                var typologyReader = await typologyQuerry.ExecuteReaderAsync();

                while (typologyReader.Read())
                {
                    var typologyModel = new TypologyModel();
                    typologyModel.Description = typologyReader["descricao"].ToString();
                    typologyModel.Id = (int)typologyReader["id"];
                    refData.TypologiesList.Add(typologyModel);
                }

                typologyReader.Close();

                using var realEstateTypeQuerry = new NpgsqlCommand("SELECT * FROM tipo_imovel;", conn);
                var realEstateTypeReader = await realEstateTypeQuerry.ExecuteReaderAsync();

                while (realEstateTypeReader.Read())
                {
                    var realEstateTypeModel = new RealEstateTypeModel();
                    realEstateTypeModel.Description = realEstateTypeReader["descricao"].ToString();
                    realEstateTypeModel.Id = (int)realEstateTypeReader["id"];
                    refData.RealEstateTypesList.Add(realEstateTypeModel);
                }

                realEstateTypeReader.Close();

                using var cityQuerry = new NpgsqlCommand("SELECT * FROM cidades;", conn);
                var cityReader = await cityQuerry.ExecuteReaderAsync();

                while (cityReader.Read())
                {
                    var citiesModel = new CityModel();
                    citiesModel.Description = cityReader["descricao"].ToString();
                    citiesModel.Id = (int)cityReader["id"];
                    refData.CitiesList.Add(citiesModel);
                }

                cityReader.Close();

                using var amenitiesQuerry = new NpgsqlCommand("SELECT * FROM cidades;", conn);
                var amenitiesReader = await cityQuerry.ExecuteReaderAsync();

                while (cityReader.Read())
                {
                    var amenitiesModel = new AmenitiesModel();
                    amenitiesModel.Description = amenitiesReader["descricao"].ToString();
                    amenitiesModel.Id = (int)amenitiesReader["id"];
                    refData.AmenitiesList.Add(amenitiesModel);
                }

                cityReader.Close();

                return refData;
            }
        }

        public async Task<string?> GetUserName()
        {
            using (var conn = await _dataSource.OpenConnectionAsync())
            {
                using var command = new NpgsqlCommand("SELECT nome FROM vendedor;", conn);
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
