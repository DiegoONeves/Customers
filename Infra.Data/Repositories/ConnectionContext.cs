using MySqlConnector;

namespace Infra.Data.Repositories
{
    public class ConnectionContext(MySqlConnectionString MySqlConnectionString)
    {
        public MySqlConnection GetConnection() => new(MySqlConnectionString.ConnectionString);
    }
}