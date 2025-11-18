namespace Infra.Data.Repositories
{
    public record MySqlConnectionString
    {
        public MySqlConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; private set; }
    }
}
