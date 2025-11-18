using Application.Features.Customers.Commands;
using Application.Repositories;
using Domain.Entities;
using Infra.Data.Repositories;

namespace Application.Features.Customers.Handlers
{
    public class CreateCustomerCommandHandler(ConnectionContext context, ICustomerRepository customerRepository) 
    {
        ConnectionContext _context = context;
        ICustomerRepository _customerRepository = customerRepository;
        public async Task<Result<Guid>> Handle(CreateCustomerCommand command)
        {
            var newCustomer = new Customer(command.FirstName, command.LastName, command.BirthDate, command.Occupation);
            using (var connection = _context.GetConnection())
            {
                await connection.OpenAsync();
                var transaction = await connection.BeginTransactionAsync();

                await _customerRepository.CreateAsync(connection, newCustomer, transaction);

                await transaction.CommitAsync();
            }

            return Result<Guid>.Success(newCustomer.Id);
        }
    }
}
