using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace Book.Infra.Data.Context
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; set; }
        public DbSession(IConfiguration configuration) 
        {
            Connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
        
    }
}
