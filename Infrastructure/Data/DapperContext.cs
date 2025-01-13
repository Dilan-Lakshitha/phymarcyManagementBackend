using System.Data;
using Npgsql; // Add this line
using Microsoft.Extensions.Configuration;

namespace phymarcyManagement.Infrastructure.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
