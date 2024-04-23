using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using System;

namespace RealEstateApi.Repository
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public RealEstateRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<List<RealEstateModel>> GetAllRealEstateAsync()
        {
            List<RealEstateModel> realEstate = new();
            
            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var realEstateQuerry = new NpgsqlCommand("SELECT * FROM realestate;", conn);
                using var realEstateReader = await realEstateQuerry.ExecuteReaderAsync();

                while (realEstateReader.Read())
                {
                    var realEstateModel = new RealEstateModel
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
                        CustomerId = (int)realEstateReader["fk_customer_id"],
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
        public async Task<RealEstateModel> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            RealEstateModel response = new();

            try
            {
                using var conn = await _dataSource.OpenConnectionAsync();
                using var query = new NpgsqlCommand(@"INSERT INTO realestate(title, address, zip_code, description, build_date, price, square_meter, energy_class, fk_customer_id, fk_agent_id, fk_realestate_type_id, fk_city_id, fk_typology_id) VALUES (@realEstateTitle, @realEstateAddress, @realEstateZipcode, @realEstateDescription, @realEstateBuild_Date, @realEstatePrice, @realEstateSquareMeter, @realEstateEnergyClass, @realEstateCustomerId, @realEstateAgentId, @realEstateRealEstateTypeId, @realEstateCityId, @realEstateTypologyId) returning id;", conn);

                query.Parameters.Add(new NpgsqlParameter("@realEstateTitle", NpgsqlDbType.Text) { Value = realEstateDto.Title });
                query.Parameters.Add(new NpgsqlParameter("@realEstateAddress", NpgsqlDbType.Text) { Value = realEstateDto.Address });
                query.Parameters.Add(new NpgsqlParameter("@realEstateZipCode", NpgsqlDbType.Text) { Value = realEstateDto.ZipCode });
                query.Parameters.Add(new NpgsqlParameter("@realEstateDescription", NpgsqlDbType.Text) { Value = realEstateDto.Description });
                query.Parameters.Add(new NpgsqlParameter("@realEstateBuild_Date", NpgsqlDbType.Date) { Value = realEstateDto.Build_Date });
                query.Parameters.Add(new NpgsqlParameter("@realEstatePrice", NpgsqlDbType.Numeric) { Value = realEstateDto.Price });
                query.Parameters.Add(new NpgsqlParameter("@realEstateSquareMeter", NpgsqlDbType.Integer) { Value = realEstateDto.SquareMeter });
                query.Parameters.Add(new NpgsqlParameter("@realEstateEnergyClass", NpgsqlDbType.Text) { Value = realEstateDto.EnergyClass });
                query.Parameters.Add(new NpgsqlParameter("@realEstateCustomerId", NpgsqlDbType.Integer) { Value = realEstateDto.CustomerId });
                query.Parameters.Add(new NpgsqlParameter("@realEstateAgentId", NpgsqlDbType.Integer) { Value = realEstateDto.AgentId });
                query.Parameters.Add(new NpgsqlParameter("@realEstateRealEstateTypeId", NpgsqlDbType.Integer) { Value = realEstateDto.RealEstateTypeId });
                query.Parameters.Add(new NpgsqlParameter("@realEstateCityId", NpgsqlDbType.Integer) { Value = realEstateDto.CityId });
                query.Parameters.Add(new NpgsqlParameter("@realEstateTypologyId", NpgsqlDbType.Integer) { Value = realEstateDto.TypologyId });

                var result = await query.ExecuteScalarAsync();

                response = new RealEstateModel
                {
                    Id = (int)result,
                    Title = realEstateDto.Title,
                    Address = realEstateDto.Address,
                    ZipCode = realEstateDto.ZipCode,
                    Description = realEstateDto.Description,
                    Build_Date = realEstateDto.Build_Date,
                    Price = realEstateDto.Price,
                    EnergyClass = realEstateDto.EnergyClass,
                    SquareMeter = realEstateDto.SquareMeter,
                    CustomerId = realEstateDto.CustomerId,
                    AgentId = realEstateDto.AgentId,
                    RealEstateTypeId = realEstateDto.RealEstateTypeId,
                    CityId = realEstateDto.CityId,
                    TypologyId = realEstateDto.TypologyId,
                };
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return response;
        }
    }
}