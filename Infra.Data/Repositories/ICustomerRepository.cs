using Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Application.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateAsync(SqlConnection connection, Customer customer, DbTransaction? transaction);
    }
}
