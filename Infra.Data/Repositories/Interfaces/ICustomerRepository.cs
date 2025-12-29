using Domain.Entities;
using MySqlConnector;
using System.Data.Common;

namespace Infra.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(MySqlConnection connection, Customer customer, DbTransaction? transaction, CancellationToken cancellationToken);
        Task UpdateAsync(MySqlConnection connection, Customer customer, DbTransaction? transaction, CancellationToken cancellationToken);
        Task<Customer> GetByIdAsync(MySqlConnection connection, Guid id, DbTransaction? transaction, CancellationToken cancellationToken);
        Task<IEnumerable<Customer>> GetAllAsync(MySqlConnection connection, DbTransaction? transaction, CancellationToken cancellationToken);
    }
}
