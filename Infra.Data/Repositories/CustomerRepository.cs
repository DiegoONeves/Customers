using Application.Repositories;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task CreateAsync(
            SqlConnection connection,
            Customer customer,
            DbTransaction? transaction = null)
        {
            const string sql = @"
        INSERT INTO [dbo].[Customer]
        (
            Id,
            FirstName,
            LastName,
            BirthDate,
            Occupation,
            CreateDateTime,
            UpdateDateTime
        )
        VALUES
        (
            @Id,
            @FirstName,
            @LastName,
            @BirthDate,
            @Occupation,
            @CreateDateTime,
            @UpdateDateTime
        );";

            await connection.ExecuteAsync(sql, customer, transaction);
        }
    }
}
