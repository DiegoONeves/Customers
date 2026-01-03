using Dapper;
using Domain.Entities;
using Infra.Data.Repositories.Interfaces;
using MySqlConnector;
using System.Data.Common;

namespace Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task CreateAsync(
     MySqlConnection connection,
     Customer customer,
     DbTransaction? transaction,
     CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            const string sqlCustomer = @"
INSERT INTO Customer
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

            var customerParams = new
            {
                Id = customer.Id.ToByteArray(),
                customer.FirstName,
                customer.LastName,
                customer.BirthDate,
                customer.Occupation,
                customer.CreateDateTime,
                customer.UpdateDateTime
            };

            await connection.ExecuteAsync(
                new CommandDefinition(
                    sqlCustomer,
                    customerParams,
                    transaction,
                    cancellationToken: cancellationToken
                )
            );

            // ---------- Addresses ----------
            const string sqlAddress = @"
INSERT INTO Address
(
    Id,
    CustomerId,
    PostalCode,
    Neighborhood,
    Street,
    Number,
    Complement,
    IsPrincipal,
    CityId,
    State,
    CreateDateTime,
    UpdateDateTime
)
VALUES
(
    @Id,
    @CustomerId,
    @PostalCode,
    @Neighborhood,
    @Street,
    @Number,
    @Complement,
    @IsPrincipal,
    @CityId,
    @State,
    @CreateDateTime,
    @UpdateDateTime
);";

            foreach (var address in customer.Addresses)
            {
                var addressParams = new
                {
                    Id = address.Id.ToByteArray(),
                    CustomerId = customer.Id.ToByteArray(),
                    address.PostalCode,
                    address.Neighborhood,
                    address.Street,
                    address.Number,
                    address.Complement,
                    address.IsPrincipal,
                    CityId = address.City.Id.ToByteArray(),
                    State = address.State.Value,
                    address.CreateDateTime,
                    address.UpdateDateTime
                };

                await connection.ExecuteAsync(
                    new CommandDefinition(
                        sqlAddress,
                        addressParams,
                        transaction,
                        cancellationToken: cancellationToken
                    )
                );
            }
        }


        public Task<IEnumerable<Customer>> GetAllAsync(MySqlConnection connection, DbTransaction? transaction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(MySqlConnection connection, Guid id, DbTransaction? transaction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MySqlConnection connection, Customer customer, DbTransaction? transaction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
