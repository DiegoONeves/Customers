using Domain.Entities;
using Infra.Data.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories.Interfaces
{
    public class AddressRepository : IAddressRepository
    {
        public Task CreateAsync(SqlConnection connection, Address address, DbTransaction? transaction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(SqlConnection connection, Guid id, DbTransaction? transaction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetByCustomerIdAsync(SqlConnection connection, Guid customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(SqlConnection connection, Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SqlConnection connection, Address address, DbTransaction? transaction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
