namespace Domain.Common.Entities
{
    public class Entity : IEntity
    {
        public virtual int Id { get; protected set; }
    }
}
