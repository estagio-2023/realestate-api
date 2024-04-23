using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;

namespace RealEstateApi.Repository
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public RealEstateRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<List<RealEstateRequestDto>> GetAllRealEstateAsync()
        {
            List<RealEstateRequestDto> realEstate = new();
            using var conn = await _dataSource.OpenConnectionAsync();

            using var realEstateQuerry = new NpgsqlCommand("SELECT * FROM realestate;", conn);
            using var realEstateReader = await realEstateQuerry.ExecuteReaderAsync();
            try
            {
                while (realEstateReader.Read())
                {
                    var RealEstateRequestDto = new RealEstateRequestDto
                    {
                        Id = (int)realEstateReader["id"],
                        Title = (string)realEstateReader["title"],
                        CityId = (int)realEstateReader["fk_city_id"],
                        TypologyId = (int)realEstateReader["fk_typology_id"]
                    };
                    realEstate.Add(RealEstateRequestDto);
                }
                realEstateReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return realEstate;
        }
    }
}
