using Application.Repositories;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task CreateAsync(SqlConnection connection, Customer customer, DbTransaction? transaction = null)
        {
            await connection.ExecuteAsync("", customer, transaction);
        }
    }
}
