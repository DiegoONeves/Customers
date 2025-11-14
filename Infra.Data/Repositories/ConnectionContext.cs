using Microsoft.Data.SqlClient;

namespace Infra.Data.Repositories
{
    public class ConnectionContext
    {
        public SqlConnection GetConnection() => new("");
    }
}
