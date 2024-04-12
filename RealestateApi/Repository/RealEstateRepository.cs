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

        public async Task<List<RealEstate>> GetAllRealEstateAsync()
        {
            List<RealEstate> realEstate = new();
            using var conn = await _dataSource.OpenConnectionAsync();

            using var realEstateQuerry = new NpgsqlCommand("SELECT * FROM realestate;", conn);
            using var realEstateReader = await realEstateQuerry.ExecuteReaderAsync();
            try
            {
                while (realEstateReader.Read())
                {
                    var realEstateModel = new RealEstate
                    {
                        Id = (int)realEstateReader["id"],
                        Title = (string)realEstateReader["title"],
                        Address = (string)realEstateReader["address"],
                        ZipCode = (string)realEstateReader["zip_code"],
                        Description = (string)realEstateReader["description"],
                        Build_Date = (DateTime)realEstateReader["build_date"],
                        Price = (decimal)realEstateReader["price"],
                        SquareMeter = (int)realEstateReader["square_meter"],
                        EnergyClass = (string)realEstateReader["energy_class"],
                        ClientId = (int)realEstateReader["fk_client_id"],
                        AgentId = (int)realEstateReader["fk_agent_id"],
                        RealEstateTypeId = (int)realEstateReader["fk_realestate_type_id"],
                        CityId = (int)realEstateReader["fk_city_id"],
                        TypologyId = (int)realEstateReader["fk_typology_id"]
                    };
                    realEstate.Add(realEstateModel);
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
