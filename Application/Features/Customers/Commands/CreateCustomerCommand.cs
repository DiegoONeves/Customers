namespace Application.Features.Customers.Commands
{
    public class CreateCustomerCommand 
    {
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required DateOnly BirthDate { get; set; }
        public required string Occupation { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{{ FirstName: \"{FirstName}\", LastName: \"{LastName}\", BirthDate: \"{BirthDate:yyyy-MM-dd}\", Occupation: \"{Occupation}\" }}";
        }

    }
}
