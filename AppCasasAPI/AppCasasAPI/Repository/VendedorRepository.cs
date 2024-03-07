using Npgsql;
using AppCasasAPI.Repository.Interfaces;

namespace AppCasasAPI.Repository
{
    
    public class VendedorRepository : IVendedorRepository
    {
        private readonly NpgsqlConnection _connection;

        public async Task<string> GetUserName()
        {
            await _connection.OpenAsync();
            await using var command = new NpgsqlCommand("SELECT name FROM vendedor;");
            return (string)await command.ExecuteScalarAsync();   

        }
    }
}

