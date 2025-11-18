namespace Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string firstName, string lastName, DateOnly birthDate, string occupation)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate.ToDateTime(TimeOnly.MinValue);
            Occupation = occupation;
        }

        // Construtor protegido só pra ORMs (Dapper, EF, etc.)
        protected Customer() { }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public string Occupation { get; private set; } = string.Empty;

        public override string ToString() 
            => $"First name: {FirstName} - Last name: {LastName} - Birth date: {BirthDate} - Occupation: {Occupation}";
        

    }
}
