using Microsoft.VisualBasic;
using Npgsql;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using System.Data.Common;

namespace RealEstateApi.Repository
{
    public class VisitRequestRepository: IVisitRequestRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public VisitRequestRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        /// <summary>
        /// 
        /// Gets a List of all Visit Requests from Database
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        public async Task<List<VisitRequestModel>> GetAllVisitRequestsAsync()
        {
            List<VisitRequestModel> response = new();

            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("SELECT id, name, email, to_char(date, 'DD-MM-YYYY') AS date, start_time, end_time, confirmed, fk_realestate_id, fk_agent_id FROM visit_request;", conn);
            using var reader = await query.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var visitRequestModel = new VisitRequestModel
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Email = (string)reader["email"],
                        Date = (string)reader["date"],
                        StartTime = (TimeSpan)reader["start_time"],
                        EndTime = (TimeSpan)reader["end_time"],
                        Confirmed = (bool)reader["confirmed"],
                        FkRealEstateId = (int)reader["fk_realestate_id"],
                        FkAgentId = (int)reader["fk_agent_id"]
                    };
                    response.Add(visitRequestModel);
                }
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gets all the visit request by fk_realestate_id from the Database
        /// 
        /// </summary>
        /// <param name="realEstateId"> Id of fk_realestate_id </param>
        /// <returns> List<VisitRequestModel> </returns>
        public async Task<List<VisitRequestModel>> GetAllVisitRequestsByIdAsync(int realEstateId)
        {
            List<VisitRequestModel> response = new();

            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("SELECT * WHERE fk_realestate_id = @realEstateId;", conn);
            query.Parameters.AddWithValue("@realEstateId", realEstateId);

            using var reader = await query.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var visitRequestModel = new VisitRequestModel
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Email = (string)reader["email"],
                        Date = (string)reader["date"],
                        StartTime = (TimeSpan)reader["start_time"],
                        EndTime = (TimeSpan)reader["end_time"],
                        Confirmed = (bool)reader["confirmed"],
                        FkRealEstateId = (int)reader["fk_realestate_id"],
                        FkAgentId = (int)reader["fk_agent_id"]
                    };
                    response.Add(visitRequestModel);
                }
            }

            return response;
        }
    }
}
