using Npgsql;
using AppCasasAPI.Repository.Interfaces;

namespace AppCasasAPI.Repository
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public VendedorRepository(NpgsqlDataSource dataSource) {
            _dataSource = dataSource;
        }

        public async Task<string?> GetUserName()
        {
            using (var conn = await _dataSource.OpenConnectionAsync())
            {
                using var command = new NpgsqlCommand("SELECT nome FROM agent;", conn);
                var execute = await command.ExecuteScalarAsync();
                if (execute != null)
                {
                    return execute.ToString();
                }
                return null;
            }            
        }
    }
}
