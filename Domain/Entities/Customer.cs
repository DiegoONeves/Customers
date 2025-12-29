namespace Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string firstName, string lastName, DateOnly birthDate, string occupation, IEnumerable<Address> addresses)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new Exception("First name is required");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new Exception("Last name is required");

            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            if (birthDate > today)
                throw new Exception("Birth date cannot be in the future");

            if (string.IsNullOrWhiteSpace(occupation))
                throw new Exception("Occupation is required");

            if (addresses is null)
                throw new Exception("Addresses collection cannot be null");

            var addressList = addresses.ToList();

            if (addressList.Count == 0)
                throw new Exception("At least one address is required");

            // (opcional) validação leve nos endereços
            if (addressList.Any(a => string.IsNullOrWhiteSpace(a.PostalCode)))
                throw new Exception("Address must have a postal code");

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            BirthDate = birthDate.ToDateTime(TimeOnly.MinValue);
            Occupation = occupation.Trim();
            Addresses = addressList;
        }

        public Customer(Guid customerId, 
            DateTime createDateTime, 
            string firstName, 
            string lastName, 
            DateOnly birthDate, 
            string occupation, 
            IEnumerable<Address> addresses, 
            DateTime? updateDateTime = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new Exception("First name is required");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new Exception("Last name is required");

            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            if (birthDate > today)
                throw new Exception("Birth date cannot be in the future");

            if (string.IsNullOrWhiteSpace(occupation))
                throw new Exception("Occupation is required");

            if (addresses is null)
                throw new Exception("Addresses collection cannot be null");

            var addressList = addresses.ToList();

            if (addressList.Count == 0)
                throw new Exception("At least one address is required");

            // (opcional) validação leve nos endereços
            if (addressList.Any(a => string.IsNullOrWhiteSpace(a.PostalCode)))
                throw new Exception("Address must have a postal code");

            Id = customerId;
            CreateDateTime = createDateTime;
            UpdateDateTime = updateDateTime;
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            BirthDate = birthDate.ToDateTime(TimeOnly.MinValue);
            Occupation = occupation.Trim();
            Addresses = addressList;
        }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public string Occupation { get; private set; } = string.Empty;
        public IEnumerable<Address> Addresses { get; set; } = [];

        public override string ToString() 
            => $"First name: {FirstName} - Last name: {LastName} - Birth date: {BirthDate} - Occupation: {Occupation}";
        

    }
}
