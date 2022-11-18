using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace abcc.repository.Infraestructure.Context
{
    public class ContextDapper
    {
        private readonly IConfiguration _configuration;

        public ContextDapper(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IDbConnection CreateConnection() => new MySqlConnection(_configuration.GetConnectionString("DefaultConnectoin")); 

    }
}
