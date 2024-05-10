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

        /// <summary>
        /// 
        /// Gets all the Real Estates from the Database
        /// 
        /// </summary>
        /// <returns> List<RealEstateRequestDto> </returns>
        public async Task<List<RealEstateRequestDto>> GetAllRealEstateAsync()
        {
            List<RealEstateRequestDto> response = new();

            using var conn = await _dataSource.OpenConnectionAsync();
            
            using var realEstateQuerry = new NpgsqlCommand("SELECT * FROM realestate;", conn);
            using var realEstateReader = await realEstateQuerry.ExecuteReaderAsync();
            
            if (realEstateReader.HasRows)
            {
                while (realEstateReader.Read())
                {
                    var realEstateRequestDto = new RealEstateRequestDto
                    {
                        Id = (int)realEstateReader["id"],
                        Title = (string)realEstateReader["title"],
                        CityId = (int)realEstateReader["fk_city_id"],
                        TypologyId = (int)realEstateReader["fk_typology_id"]
                    };
                    response.Add(realEstateRequestDto);
                }
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gets a Real Estate by Id from the Database
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id to Get Real Estate </param>
        /// <returns> RealEstateModel </returns>
        public async Task<RealEstateModel?> GetRealEstateByIdAsync(int realEstateId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var realEstateQuerry = new NpgsqlCommand("SELECT * FROM realestate WHERE id = @RealEstateId;", conn);
            realEstateQuerry.Parameters.AddWithValue("@RealEstateId", realEstateId);

            using var realEstateReader = await realEstateQuerry.ExecuteReaderAsync();

            if (realEstateReader.HasRows)
            {
                RealEstateModel response = new();

                while (realEstateReader.Read())
                {
                    response = new RealEstateModel
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
                }

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Adds a Real Estate to the Database
        /// 
        /// </summary>
        /// <param name="realEstateDto"> Real Estate Data to be saved </param>
        /// <returns> RealEstateModel </returns>
        public async Task<RealEstateModel?> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
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

            if(result != null)
            {
                var response = new RealEstateModel
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

                return response;
            }

            return null;                
        }        

        /// <summary>
        /// 
        /// Delete a real estate by Id from the Database
        /// 
        /// </summary>
        /// <param name="realEstateId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRealEstateByIdAsync(int realEstateId)
        {

            using var conn = await _dataSource.OpenConnectionAsync();

            using var delete = new NpgsqlCommand("DELETE FROM realestate WHERE id = @realEstateId", conn);
            delete.Parameters.AddWithValue("@realEstateId", realEstateId);

            var affectedRows = await delete.ExecuteNonQueryAsync();

            return affectedRows > 0;
        }

        public async Task<RealEstateModel?> GetRealEstateByCustomerIdAsync(int customerId)
        {
            RealEstateModel response = new();            

            using var conn = await _dataSource.OpenConnectionAsync();

            using var realEstateQuery = new NpgsqlCommand("SELECT * FROM realestate WHERE fk_customer_id = @customerId;", conn);
            realEstateQuery.Parameters.AddWithValue("@customerId", customerId);

            using var realEstateReader = await realEstateQuery.ExecuteReaderAsync();

            if (realEstateReader.HasRows)
            {
                while (realEstateReader.Read())
                {
                    response = new RealEstateModel
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
                }

                return response;
            }
                
            return null;
        }

        public async Task<RealEstateModel?> GetRealEstateByAgentIdAsync(int agentId)
        {
            RealEstateModel response = new();

            using var conn = await _dataSource.OpenConnectionAsync();

            using var realEstateQuery = new NpgsqlCommand("SELECT * FROM realestate WHERE fk_agent_id = @agentId;", conn);
            realEstateQuery.Parameters.AddWithValue("@agentId", agentId);

            using var realEstateReader = await realEstateQuery.ExecuteReaderAsync();

            if (realEstateReader.HasRows)
            {
                while (realEstateReader.Read())
                {
                    response = new RealEstateModel
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
                }

                return response;
            }

            return null;
        }
    }
}