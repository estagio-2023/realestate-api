using Microsoft.VisualBasic;
using Npgsql;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;

namespace RealEstateApi.Repository
{
    public class VisitRequestRepository: IVisitRequestRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public VisitRequestRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<List<VisitRequestModel>> GetAllVisistRequestsAsync()
        {
            List<VisitRequestModel> response = new();

            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("SELECT * FROM visit_request;", conn);
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
                        Date = (DateTime)reader["date"],
                        StartTime = (string)reader["start_time"],
                        EndTime = (string)reader["end_time"],
                        Confirmed = (bool)reader["confirmed"],
                        FkRealEstateId = (int)reader["fk_realestate_id"],
                    };
                    response.Add(visitRequestModel);
                }
            }

            return response;
        }
    }
}
