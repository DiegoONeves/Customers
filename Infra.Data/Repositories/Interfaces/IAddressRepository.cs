using Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Infra.Data.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task CreateAsync(SqlConnection connection, Address address, DbTransaction? transaction, CancellationToken cancellationToken);
        Task UpdateAsync(SqlConnection connection, Address address, DbTransaction? transaction, CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(SqlConnection connection, Guid id, DbTransaction? transaction, CancellationToken cancellationToken);
        Task<Address> GetByIdAsync(SqlConnection connection, Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Address>> GetByCustomerIdAsync(SqlConnection connection, Guid customerId, CancellationToken cancellationToken);
    }
}
