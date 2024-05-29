using Npgsql;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Dto.Request;
using NpgsqlTypes;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            using var query = new NpgsqlCommand("SELECT id, name, email, TO_CHAR(date, 'DD-MM-YYYY') AS date, start_time, end_time, confirmed, fk_realestate_id, fk_agent_id FROM visit_request;", conn);
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

            using var query = new NpgsqlCommand("SELECT id, name, email, TO_CHAR(date, 'DD-MM-YYYY') AS date, start_time, end_time, confirmed, fk_realestate_id, fk_agent_id FROM visit_request WHERE id = @visitRequestId;", conn);
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
        /// Updates Visit Request Confirmation in the Database
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Visit Request ID to update Visit Request confirmation </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<VisitRequestModel?> UpdateVisitRequestConfirmationByIdAsync(int visitRequestId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            var visitRequestData = await GetVisitRequestByIdAsync(visitRequestId);

            if(visitRequestData == null)
            {
                return null;
            }

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

        /// <summary>
        /// 
        /// Gets a List of all Visit Requests by Realestate Id from Database
        /// 
        /// </summary>
        /// <returns> List<VisitRequestModel> </returns>
        public async Task<List<VisitRequestModel>> GetAllVisitRequestsByRealEstateIdAsync(int realEstateId)
        {
            List<VisitRequestModel> response = new();

            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("SELECT id, name, email, to_char(date, 'DD-MM-YYYY') AS date, start_time, end_time, confirmed, fk_realestate_id, fk_agent_id FROM visit_request WHERE fk_realestate_id = @realEstateId;", conn);
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

        /// <summary>
        /// 
        /// Deletes a Visit Request by Id from the Database
        /// 
        /// </summary>
        /// <param name="visitRequestId"> Id to get Visit Request </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<bool> DeleteVisitRequestByIdAsync(int visitRequestId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var delete = new NpgsqlCommand("DELETE FROM visit_request WHERE id = @visitRequestId", conn);
            delete.Parameters.AddWithValue("@visitRequestId", visitRequestId);

            var affectedRows = await delete.ExecuteNonQueryAsync();

            return affectedRows > 0;
        }

        /// <summary>
        /// 
        /// Adds a Visit Request to the Database
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to be created </param>
        /// <returns> VisitRequestModel </returns>
        public async Task<VisitRequestModel?> AddVisitRequestAsync(VisitRequestDto visitRequestData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("INSERT INTO visit_request (name, email, date, start_time, end_time, confirmed, fk_realestate_id, fk_agent_id ) VALUES (@name, @email, @date, @start_time, @end_time, @confirmed, @fk_realestate_id, @fk_agent_id) RETURNING id", conn);
            query.Parameters.AddWithValue("@name", visitRequestData.Name);
            query.Parameters.AddWithValue("@email", visitRequestData.Email);
            query.Parameters.AddWithValue("@date", DateTime.Parse(visitRequestData.Date));
            query.Parameters.AddWithValue("@start_time", TimeSpan.Parse(visitRequestData.StartTime));
            query.Parameters.AddWithValue("@end_time", TimeSpan.Parse(visitRequestData.EndTime));
            query.Parameters.AddWithValue("@confirmed", false);
            query.Parameters.AddWithValue("@fk_realestate_id", visitRequestData.RealEstateId);
            query.Parameters.AddWithValue("@fk_agent_id", visitRequestData.AgentId);

            var result = await query.ExecuteScalarAsync();

            if (result != null)
            {
                var response = new VisitRequestModel
                {
                    Id = (int)result,
                    Name = visitRequestData.Name,
                    Email = visitRequestData.Email,
                    Date = visitRequestData.Date,
                    StartTime = TimeSpan.Parse(visitRequestData.StartTime),
                    EndTime = TimeSpan.Parse(visitRequestData.EndTime),
                    Confirmed = false,
                    FkRealEstateId = visitRequestData.RealEstateId,
                    FkAgentId = visitRequestData.AgentId
                };

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Gets a Visit Request by realestate id, date, start_time and end_time from the Database
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to get Visit Request </param>
        /// <returns> bool </returns>
        public async Task<bool> ExistingRealEstateId(VisitRequestDto visitRequestData) 
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var realEstateIdQuery = new NpgsqlCommand("SELECT * FROM visit_request WHERE fk_realestate_id = @fk_realestate_id AND date = @date AND ((start_time BETWEEN @start_time AND @end_time) OR (end_time BETWEEN @start_time AND @end_time))", conn);
            realEstateIdQuery.Parameters.AddWithValue("@fk_realestate_id", visitRequestData.RealEstateId);
            realEstateIdQuery.Parameters.AddWithValue("@date", DateTime.Parse(visitRequestData.Date));
            realEstateIdQuery.Parameters.AddWithValue("@start_time", TimeSpan.Parse(visitRequestData.StartTime));
            realEstateIdQuery.Parameters.AddWithValue("@end_time", TimeSpan.Parse(visitRequestData.EndTime));

            using (var realEstateIdReader = await realEstateIdQuery.ExecuteReaderAsync())
            {
                if (realEstateIdReader.HasRows)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// Gets a Visit Request by agent id, date, start_time and end_time from the Database
        /// 
        /// </summary>
        /// <param name="visitRequestData"> Visit Request Data to get Visit Request </param>
        /// <returns> bool </returns>
        public async Task<bool> ExistingAgentId(VisitRequestDto visitRequestData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var agentIdQuery = new NpgsqlCommand("SELECT * FROM visit_request WHERE fk_agent_id = @fk_agent_id AND date = @date AND ((start_time BETWEEN @start_time AND @end_time) OR (end_time BETWEEN @start_time AND @end_time))", conn);
            agentIdQuery.Parameters.AddWithValue("@fk_agent_id", visitRequestData.AgentId);
            agentIdQuery.Parameters.AddWithValue("@date", DateTime.Parse(visitRequestData.Date));
            agentIdQuery.Parameters.AddWithValue("@start_time", TimeSpan.Parse(visitRequestData.StartTime));
            agentIdQuery.Parameters.AddWithValue("@end_time", TimeSpan.Parse(visitRequestData.EndTime));

            using (var agentIdReader = await agentIdQuery.ExecuteReaderAsync())
            {
                if (agentIdReader.HasRows)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
