using Domain.Common;

namespace Domain.Entities
{
    public class Entity : IEntity
    {
        public virtual int Id { get; protected set; }
    }
}
