namespace Application.Features.Customers.Commands
{
    public class CreateCustomerCommand 
    {
        public required string FirstName { get; init; } = string.Empty;
        public required string LastName { get; init; } = string.Empty;
        public required DateOnly BirthDate { get; init; }
        public required string Occupation { get; init; } = string.Empty;
        public IReadOnlyCollection<Address> Addresses { get; init; } = Array.Empty<Address>();
        public override string ToString() 
            => $"{{ FirstName: \"{FirstName}\", LastName: \"{LastName}\", BirthDate: \"{BirthDate:yyyy-MM-dd}\", Occupation: \"{Occupation}\" }}";

        public record Address(
     string PostalCode,
     string? Complement,
     string Number,
     string Street,
     string Neighborhood,
     string City,
     string State,
     bool isPrincipal
 );

    }
}
