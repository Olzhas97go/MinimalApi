using System.Data;
using Npgsql;

namespace MinimalApi.Data;
public class DapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    
    public DapperContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Failed to find connection string.");
        }
    }
    
    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);
}