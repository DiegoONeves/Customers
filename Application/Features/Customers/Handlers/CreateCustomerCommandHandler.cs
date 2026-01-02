using Application.Features.Customers.Commands;
using Domain.Entities;
using Domain.ValueObjects;
using Infra.ClientApi;
using Infra.Data.Repositories;
using Infra.Data.Repositories.Interfaces;

namespace Application.Features.Customers.Handlers
{
    public class CreateCustomerCommandHandler(ConnectionContext context,
        ICustomerRepository customerRepository,
        ICityRepository cityRepository,
        IResilientApiClient api)
    {
        ConnectionContext _context = context;
        ICustomerRepository _customerRepository = customerRepository;
        ICityRepository _cityRepository = cityRepository;
        private readonly IResilientApiClient _api = api;
        public async Task<Result<Guid>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            using (var connection = _context.GetConnection())
            {
                await connection.OpenAsync();
                var transaction = await connection.BeginTransactionAsync();

                var addresses = new List<Address>();
                foreach (var item in command.Addresses)
                {
                    var data = await _api.GetAsync<object>("via-cep", $"/ws/{item.PostalCode}/json/");

                    var state = new State(item.State);

                    City? city = await _cityRepository.GetByNameAsync(connection, transaction, item.City, cancellationToken);

                    if (city is null)
                    {
                        city = new City(item.City, state);

                        await _cityRepository.CreateAsync(connection, city, transaction, cancellationToken);
                    }

                    addresses.Add(new Address(item.PostalCode, item.Neighborhood, item.Street, item.Number, item.isPrincipal, city, item.Complement));
                }

                var newCustomer = new Customer(command.FirstName, command.LastName, command.BirthDate, command.Occupation, addresses);

                await _customerRepository.CreateAsync(connection, newCustomer, transaction, cancellationToken);

                await transaction.CommitAsync();

                return Result<Guid>.Success(newCustomer.Id);
            }
        }
    }
}
