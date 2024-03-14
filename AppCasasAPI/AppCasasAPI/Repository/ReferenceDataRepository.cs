using Npgsql;
using AppCasasAPI.Repository.Interfaces;
using AppCasasAPI.Dto.Response;
using AppCasasAPI.Model;

namespace AppCasasAPI.Repository
{
    public class ReferenceDataRepository : IReferenceDataRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public ReferenceDataRepository(NpgsqlDataSource dataSource) {
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
                    refData.TypologiesList.Add(typologyModel);
                }

                typologyReader.Close();


                using var realEstateTypeQuerry = new NpgsqlCommand("SELECT * FROM tipo_imovel;", conn);
                var realEstateTypeReader = await realEstateTypeQuerry.ExecuteReaderAsync();

                while (realEstateTypeReader.Read())
                {
                    var realEstateTypeModel = new RealEstateTypeModel();
                    realEstateTypeModel.Description = realEstateTypeReader["descricao"].ToString();
                    refData.RealEstateTypesList.Add(realEstateTypeModel);
                }

                realEstateTypeReader.Close();

                using var cityQuerry = new NpgsqlCommand("SELECT * FROM cidades;", conn);
                var cityReader = await cityQuerry.ExecuteReaderAsync();

                while (cityReader.Read())
                {
                    var citiesModel = new CityModel();
                    citiesModel.Description = cityReader["descricao"].ToString();
                    refData.CitiesList.Add(citiesModel);
                }

                cityReader.Close();

                using var amenitiesQuerry = new NpgsqlCommand("SELECT * FROM cidades;", conn);
                var amenitiesReader = await cityQuerry.ExecuteReaderAsync();

                while (cityReader.Read())
                {
                    var amenitiesModel = new AmenitiesModel();
                    amenitiesModel.Description = amenitiesReader["descricao"].ToString();
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
