using Domain.Entities;
using MySqlConnector;
using System.Data.Common;

namespace Infra.Data.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task CreateAsync(MySqlConnection connection, City city, DbTransaction? transaction, CancellationToken cancellationToken);
        Task<City> GetByIdAsync(MySqlConnection connection, Guid id, CancellationToken cancellationToken);
        Task<City?> GetByNameAsync(MySqlConnection connection, DbTransaction? transaction, string name, CancellationToken cancellationToken);
    }
}
