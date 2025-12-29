using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Address: Entity
    {
        public Address(Guid addressId, 
            string postalCode, 
            string neighborhood, 
            string street, 
            string number, 
            City city, 
            DateTime createDateTime, 
            bool isPrincipal, 
            DateTime? updateDateTime = null,
            string? complement = null)
        {
            Id = addressId;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            Street = street;
            Number = number;
            CreateDateTime = createDateTime;
            City = city;
            State = city.State;
            UpdateDateTime = updateDateTime;
            IsPrincipal = isPrincipal;
            Complement = complement;

        }
        public Address(string postalCode, 
            string neighborhood, 
            string street, 
            string number, 
            bool isPrincipal, 
            City city,
            string? complement = null)
        {
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            Complement = complement;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = city.State;
            IsPrincipal = isPrincipal;
        }
        public State State { get; protected set; }
        public City City { get; protected set; }
        public string PostalCode { get; protected set; }
        public string Neighborhood { get; protected set; }
        public string Street { get; protected set; }
        public string? Complement { get; protected set; }
        public string Number { get; protected set; }
        public bool IsPrincipal { get; protected set; }
    }
}
