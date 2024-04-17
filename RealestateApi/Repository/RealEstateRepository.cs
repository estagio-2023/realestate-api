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
                        EnergyClass = (char)realEstateReader["energy_class"],
                        CustomerId = (int)realEstateReader["fk_client_id"],
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
        public async Task<List<RealEstate>> AddRealEstateAsync(AddRealEstateRequestDto realEstateData)
        {
            List<RealEstate> response = new List<RealEstate>();
            using var conn = await _dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand(@"INSERT INTO realestate(title, address, zip_code, description, build_date, price, square_meter, energy_class, fk_client_id, fk_agent_id, fk_realestate_type_id, fk_city_id, fk_typology_id) VALUES (@realEstateTitle, @realEstateAddress, @realEstateZipcode, @realEstateDescription, @realEstateBuild_Date, @realEstatePrice, @realEstateSquareMeter, @realEstateEnergyClass, @realEstateClientId, @realEstateAgentId, @realEstateRealEstateTypeId, @realEstateCityId, @realEstateTypologyId) returning id;", conn);

            query.Parameters.Add(new NpgsqlParameter("@realEstateTitle", NpgsqlDbType.Text) { Value = realEstateData.Title });
            query.Parameters.Add(new NpgsqlParameter("@realEstateAddress", NpgsqlDbType.Text) { Value = realEstateData.Address });
            query.Parameters.Add(new NpgsqlParameter("@realEstateZipCode", NpgsqlDbType.Text) { Value = realEstateData.ZipCode });
            query.Parameters.Add(new NpgsqlParameter("@realEstateDescription", NpgsqlDbType.Text) { Value = realEstateData.Description });
            query.Parameters.Add(new NpgsqlParameter("@realEstateBuild_Date", NpgsqlDbType.Date) { Value = realEstateData.Build_Date });
            query.Parameters.Add(new NpgsqlParameter("@realEstatePrice", NpgsqlDbType.Numeric) { Value = realEstateData.Price });
            query.Parameters.Add(new NpgsqlParameter("@realEstateSquareMeter", NpgsqlDbType.Integer) { Value = realEstateData.SquareMeter });
            query.Parameters.Add(new NpgsqlParameter("@realEstateEnergyClass", NpgsqlDbType.Char) { Value = realEstateData.EnergyClass });
            query.Parameters.Add(new NpgsqlParameter("@realEstateClientId", NpgsqlDbType.Integer) { Value = realEstateData.ClientId });
            query.Parameters.Add(new NpgsqlParameter("@realEstateAgentId", NpgsqlDbType.Integer) { Value = realEstateData.AgentId });
            query.Parameters.Add(new NpgsqlParameter("@realEstateRealEstateTypeId", NpgsqlDbType.Integer) { Value = realEstateData.RealEstateTypeId });
            query.Parameters.Add(new NpgsqlParameter("@realEstateCityId", NpgsqlDbType.Integer) { Value = realEstateData.CityId });
            query.Parameters.Add(new NpgsqlParameter("@realEstateTypologyId", NpgsqlDbType.Integer) { Value = realEstateData.TypologyId });

        var result = await query.ExecuteScalarAsync();

            RealEstate realEstateResponse = new()
            {
                Id = (int)result,
                Title = realEstateData.Title,
                Address = realEstateData.Address,
                ZipCode = realEstateData.ZipCode, 
                Description = realEstateData.Description, 
                EnergyClass = realEstateData.EnergyClass, 
                SquareMeter = realEstateData.SquareMeter, 
                Build_Date = realEstateData.Build_Date, 
                Price = realEstateData.Price, 
                AgentId = realEstateData.AgentId
            };
            response.Add(realEstateResponse);

            return response;
        }
    }
}
