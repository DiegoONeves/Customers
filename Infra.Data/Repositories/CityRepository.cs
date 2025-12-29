using Dapper;
using Domain.Entities;
using Domain.ValueObjects;
using Infra.Data.Repositories.Interfaces;
using MySqlConnector;
using System.Data.Common;

namespace Infra.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        public async Task CreateAsync(
    MySqlConnection connection,
    City city,
    DbTransaction? transaction,
    CancellationToken cancellationToken)
        {
            const string sql = @"
INSERT INTO City
(
    Id,
    Name,
    State,
    CreateDateTime,
    UpdateDateTime
)
VALUES
(
    @Id,
    @Name,
    @State,
    @CreateDateTime,
    @UpdateDateTime
);";

            var parameters = new
            {
                Id = city.Id.ToByteArray(),
                city.Name,
                State = city.State.Value,
                city.CreateDateTime,
                city.UpdateDateTime
            };

            await connection.ExecuteAsync(
                new CommandDefinition(
                    sql,
                    parameters,
                    transaction,
                    cancellationToken: cancellationToken
                )
            );
        }


        public Task<City> GetByIdAsync(MySqlConnection connection, Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<City?> GetByNameAsync(MySqlConnection connection, DbTransaction? transaction, string name, CancellationToken cancellationToken)
        {
            const string sql = @" SELECT
                                    BIN_TO_UUID(Id) AS Id,
                                    Name,
                                    State,
                                    CreateDateTime,
                                    UpdateDateTime
                                FROM City
                                WHERE Name = @Name
                                LIMIT 1;";

            var row = await connection.QueryFirstOrDefaultAsync(new CommandDefinition(sql, new { @Name = name }, transaction: transaction, cancellationToken: cancellationToken));

            if (row is null)
                return null;

            var state = new State((string)row.State);

            return new City(
                (Guid)row.Id,
                (DateTime)row.CreateDateTime,
                (string)row.Name,
                state,
                (DateTime?)row.UpdateDateTime
            );
        }


    }
}
