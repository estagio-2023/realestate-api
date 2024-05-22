using Npgsql;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Dto.Request;
using NpgsqlTypes;

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
        /// Gets a Visit Request by Id from the Database
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<VisitRequestModel?> GetVisitRequestByIdAsync(int visitRequestId)
        {

            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("SELECT id, name, email, to_char(date, 'DD-MM-YYYY') AS date, start_time, end_time, confirmed, fk_realestate_id, fk_agent_id FROM visit_request WHERE id = @visitRequestId;", conn);
            query.Parameters.AddWithValue("@visitRequestId", visitRequestId);
            using var reader = await query.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                VisitRequestModel response = new();

                while (await reader.ReadAsync())
                {
                    response = new VisitRequestModel
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
                }

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Updates a Visit Request confirmation by Id to the Database
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to update a Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<VisitRequestModel?> PutVisitRequestConfirmationByIdAsync(int visitRequestId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            var visitRequestData = await GetVisitRequestByIdAsync(visitRequestId);

            using var query = new NpgsqlCommand("UPDATE visit_request SET confirmed = @confirmed WHERE id = @visitRequestId", conn);
            query.Parameters.AddWithValue("@visitRequestId", visitRequestId);
            query.Parameters.AddWithValue("@confirmed", !visitRequestData.Confirmed);

            var result = await query.ExecuteReaderAsync();

            if(result != null)
            {
                var response = new VisitRequestModel
                {
                    Id = visitRequestData.Id,
                    Name = visitRequestData.Name,
                    Email = visitRequestData.Email,
                    Date = visitRequestData.Date,
                    StartTime = visitRequestData.StartTime,
                    EndTime = visitRequestData.EndTime,
                    Confirmed = !visitRequestData.Confirmed,
                    FkRealEstateId = visitRequestData.FkRealEstateId,
                    FkAgentId = visitRequestData.FkAgentId
                };

                return response;
            }

            return null;
        }
    }
}
