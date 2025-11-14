namespace Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime CreateDateTime { get; protected set; } = DateTime.Now;

        public DateTime? UpdateDateTime { get; protected set; } = null;
    }
}
