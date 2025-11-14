namespace Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string firstName, string lastName) 
        {
            FirstName = firstName;
            LastName = lastName;    
        }

        // Construtor protegido só pra ORMs (Dapper, EF, etc.)
        protected Customer() { }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public override string ToString()
        {
            return $"First name: {FirstName} - Last name: {LastName}";
        }
        
    }
}
