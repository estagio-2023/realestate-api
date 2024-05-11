using Npgsql;
using NpgsqlTypes;
using RealEstateApi.Dto.Request;
using RealEstateApi.Dto.Response;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service;

namespace RealEstateApi.Repository
{
    public class ReferenceDataRepository : IReferenceDataRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public ReferenceDataRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        /// <summary>
        /// 
        /// Gets all Reference Data from the Database
        /// 
        /// </summary>
        /// <returns> ReferenceDataResponseDto </returns>
        public async Task<ReferenceDataResponseDto> GetAllReferenceDataAsync()
        {
            ReferenceDataResponseDto response = new();            

            using var conn = await _dataSource.OpenConnectionAsync();

            using var typologyQuerry = new NpgsqlCommand("SELECT * FROM typology;", conn);
            using var typologyReader = await typologyQuerry.ExecuteReaderAsync();

            if (typologyReader.HasRows)
            {
                while (await typologyReader.ReadAsync())
                {
                    var typologyModel = new TypologyModel
                    {
                        Description = typologyReader["description"].ToString()!,
                        Id = (int)typologyReader["id"]
                    };

                    response.Typologies.Add(typologyModel);
                }
            }

            using var realEstateTypeQuerry = new NpgsqlCommand("SELECT * FROM realestate_type;", conn);
            using var realEstateTypeReader = await realEstateTypeQuerry.ExecuteReaderAsync();

            if (realEstateTypeReader.HasRows)
            {
                while (await realEstateTypeReader.ReadAsync())
                {
                    var realEstateTypeModel = new RealEstateTypeModel
                    {
                        Description = realEstateTypeReader["description"].ToString()!,
                        Id = (int)realEstateTypeReader["id"]
                    };

                    response.RealEstateTypes.Add(realEstateTypeModel);
                }
            }

            using var cityQuerry = new NpgsqlCommand("SELECT * FROM city;", conn);
            using var cityReader = await cityQuerry.ExecuteReaderAsync();

            if (cityReader.HasRows)
            {
                while (await cityReader.ReadAsync())
                {
                    var citiesModel = new CityModel
                    {
                        Description = cityReader["description"].ToString()!,
                        Id = (int)cityReader["id"]
                    };

                    response.Cities.Add(citiesModel);
                }
            }

            using var amenitiesQuerry = new NpgsqlCommand("SELECT * FROM amenity;", conn);
            var amenitiesReader = await amenitiesQuerry.ExecuteReaderAsync();

            if (amenitiesReader.HasRows)
            {
                while (await amenitiesReader.ReadAsync())
                {
                    var amenitiesModel = new AmenitiesModel
                    {
                        Description = amenitiesReader["description"].ToString()!,
                        Id = (int)amenitiesReader["id"]
                    };

                    response.Amenities.Add(amenitiesModel);
                }
            }

            return response;
        }

        /// <summary>
        /// 
        /// Gets Typology by Id from Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ReferenceDataModel?> GetTypologyReferenceDataAsync(string refDataType, int refDataId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var typologyQuery = new NpgsqlCommand("SELECT * FROM typology WHERE id = @RefDataId;", conn);
            typologyQuery.Parameters.AddWithValue("@RefDataId", refDataId);

            using var typologyReader = await typologyQuery.ExecuteReaderAsync();

            if (typologyReader.HasRows)
            {
                ReferenceDataModel response = new();

                while (await typologyReader.ReadAsync())
                {
                    response = new ReferenceDataModel
                    {
                        Id = (int)typologyReader["id"],
                        Description = (string)typologyReader["description"],
                    };
                }

                return response;
            }

            return null;               
        }

        /// <summary>
        /// 
        /// Gets City by Id from Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ReferenceDataModel?> GetCityReferenceDataAsync(string refDataType, int refDataId)
        {
                using var conn = await _dataSource.OpenConnectionAsync();

                using var cityQuery = new NpgsqlCommand("SELECT * FROM city WHERE id = @RefDataId;", conn);
                cityQuery.Parameters.AddWithValue("@RefDataId", refDataId);
                using var cityReader = await cityQuery.ExecuteReaderAsync();

                if (cityReader.HasRows)
                {
                    ReferenceDataModel response = new();

                    while (cityReader.Read())
                    {
                        response = new ReferenceDataModel
                        {
                            Id = (int)cityReader["id"],
                            Description = (string)cityReader["description"],
                        };
                    }

                    return response;
                }

            return null;
        }

        /// <summary>
        /// 
        /// Gets Real Eatate Type by Id from Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ReferenceDataModel?> GetRealEstateReferenceDataAsync(string refDataType, int refDataId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var realEstateQuery = new NpgsqlCommand("SELECT * FROM realestate_type WHERE id = @RefDataId;", conn);
            realEstateQuery.Parameters.AddWithValue("@RefDataId", refDataId);

            using var realEstateReader = await realEstateQuery.ExecuteReaderAsync();

            if (realEstateReader.HasRows)
            {
                ReferenceDataModel response = new();

                while (realEstateReader.Read())
                {
                    response = new ReferenceDataModel
                    {
                        Id = (int)realEstateReader["id"],
                        Description = (string)realEstateReader["description"],
                    };
                }

                return response;
            }
            
            return null;
        }

        /// <summary>
        /// 
        /// Gets Amenity by Id from Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ReferenceDataModel?> GetAmenityReferenceDataAsync(string refDataType, int refDataId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var amenityQuery = new NpgsqlCommand("SELECT * FROM amenity WHERE id = @RefDataId;", conn);
            amenityQuery.Parameters.AddWithValue("@RefDataId", refDataId);

            using var amenityReader = await amenityQuery.ExecuteReaderAsync();

            if (amenityReader.HasRows)
            {
                ReferenceDataModel response = new();
                
                while (amenityReader.Read())
                {
                    response = new ReferenceDataModel
                    {
                        Id = (int)amenityReader["id"],
                        Description = (string)amenityReader["description"],
                    };
                }

                return response;
            }

            return null;            
        }

        /// <summary>
        /// 
        /// Creates a Typology in the database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refData"> Data to be saved </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ReferenceDataModel?> AddTypologyReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand(@"INSERT INTO typology(description) values(@refDataDescription) returning id;", conn);
            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            if(result != null)
            {
                var response = new ReferenceDataModel
                {
                    Id = (int)result,
                    Description = refData.Description
                };

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Creates a Real Estate Type in the Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refData"> Data to be saved </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ReferenceDataModel?> AddRealEstateTypeReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand(@"INSERT INTO realestate_type(description) values(@refDataDescription) returning id;", conn);
            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            if(result != null)
            {
                var response = new ReferenceDataModel
                {
                    Id = (int)result,
                    Description = refData.Description
                };

                return response;
            }

            return null;            
        }

        /// <summary>
        /// 
        /// Creates a City in the Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refData"> Data to be saved </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ReferenceDataModel?> AddCityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand(@"INSERT INTO city(description) values(@refDataDescription) returning id;", conn);
            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            if(result != null)
            {
                var response = new ReferenceDataModel
                {
                    Id = (int)result,
                    Description = refData.Description
                };

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Creates a Amenity in the Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refData"> Data to be saved </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<ReferenceDataModel?> AddAmenityReferenceDataAsync(string refDataType, ReferenceDataRequestDto refData)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand(@"INSERT INTO amenity(description) values(@refDataDescription) returning id;", conn);
            query.Parameters.AddWithValue("@refDataDescription", NpgsqlDbType.Text, refData.Description);

            var result = await query.ExecuteScalarAsync();

            if( result != null )
            {
                var response = new ReferenceDataModel
                {
                    Id = (int)result,
                    Description = refData.Description
                };

                return response;
            }

            return null;
        }

        /// <summary>
        /// 
        /// Deletes a Typology By Id from the database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<bool> DeleteTypologyReferenceDataAsync(string refDataType, int refDataId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var delete = new NpgsqlCommand("DELETE FROM typology WHERE id = @RefDataId", conn);
            delete.Parameters.AddWithValue("@RefDataId", refDataId);

            var affectedRows = await delete.ExecuteNonQueryAsync();

            return affectedRows > 0;
        }

        /// <summary>
        /// 
        /// Deletes a Real Estate Type By Id from the Databse
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<bool> DeleteRealEstateTypeReferenceDataAsync(string refDataType, int refDataId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var delete = new NpgsqlCommand("DELETE FROM realestate_type WHERE id = @RefDataId", conn);
            delete.Parameters.AddWithValue("@RefDataId", refDataId);

            var affectedRows = await delete.ExecuteNonQueryAsync();

            return affectedRows > 0;
        }

        /// <summary>
        /// 
        /// Deletes a City By Id from the Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<bool> DeleteCityReferenceDataAsync(string refDataType, int refDataId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var delete = new NpgsqlCommand("DELETE FROM city WHERE id = @RefDataId", conn);
            delete.Parameters.AddWithValue("@RefDataId", refDataId);

            var affectedRows = await delete.ExecuteNonQueryAsync();

            return affectedRows > 0;
        }

        /// <summary>
        /// 
        /// Deletes a Amenity By Id from the Database
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Id to delete a City </param>
        /// <returns> ReferenceDataModel </returns>
        public async Task<bool> DeleteAmenityReferenceDataAsync(string refDataType, int refDataId)
        {
            using var conn = await _dataSource.OpenConnectionAsync();

            using var delete = new NpgsqlCommand("DELETE FROM amenity WHERE id = @RefDataId", conn);
            delete.Parameters.AddWithValue("@RefDataId", refDataId);

            var affectedRows = await delete.ExecuteNonQueryAsync();

            return affectedRows > 0;
        }       
    }
}