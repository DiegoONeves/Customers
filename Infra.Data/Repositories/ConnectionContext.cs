using Microsoft.Data.SqlClient;

namespace Infra.Data.Repositories
{
    public class ConnectionContext(MySqlConnectionString MySqlConnectionString)
    {
        public SqlConnection GetConnection() => new(MySqlConnectionString.ConnectionString);
    }
}