namespace Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : ICommand<Result<Guid>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public override string ToString() => $"First name: {FirstName}";

    }
}
