using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
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
        
        public async Task<RealEstateResponseDto> GetRealEstateAsync()
        {
            RealEstateResponseDto realEstate = new();
            using var conn = await _dataSource.OpenConnectionAsync();

            using var realestateQuerry = new NpgsqlCommand("SELECT * FROM realestate;", conn);
            using var realestateReader = await realestateQuerry.ExecuteReaderAsync();
            try
            {
                while (realestateReader.Read())
                {
                    var realestateModel = new RealEstate
                    {
                        Id = (int)realestateReader["id"],
                        Title = (string)realestateReader["title"],
                        Address = (string)realestateReader["adress"],
                        ZipCode = (string)realestateReader["zip_code"],
                        Description = (string)realestateReader["description"],
                        Build_Date = (DateTime)realestateReader["build_date"],
                        Price = (decimal)realestateReader["price"],
                        SquareMeter = (int)realestateReader["square_meter"],
                        EnergyClass = (string)realestateReader["energy_class"],
                        ClientId = (int)realestateReader["fk_client_id"],
                        AgentId = (int)realestateReader["fk_agent_id"],
                        RealEstateTypeId = (int)realestateReader["fk_realestate_type_id"],
                        CityId = (int)realestateReader["fk_city_id"],
                        TypologyId = (int)realestateReader["fk_typology_id"]
                    };
                    realEstate.RealEstate.Add(realestateModel);
                }
                realestateReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return realEstate;
        }
    }
}
