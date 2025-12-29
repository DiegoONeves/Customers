using Domain.ValueObjects;

namespace Domain.Entities
{
    public class City: Entity
    {
        public City(string name, State state)
        {
            Name = name;
            State = state;
        }

        public City(Guid cityId, DateTime createDateTime, string name, State state, DateTime? updateDateTime = null)
        {
            Id = cityId;
            CreateDateTime = createDateTime;
            Name = name;
            State = state;
            UpdateDateTime = updateDateTime;
        }
        public string Name { get; protected set; }
        public State State { get; protected set; }
    }
}
