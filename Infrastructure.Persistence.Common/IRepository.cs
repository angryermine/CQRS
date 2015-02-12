using Domain.Common;

namespace Infrastructure.Persistence.Common
{
    public interface IRepository
    {
        IQueryBuilder<TEntity> Query<TEntity>() where TEntity : IEntity;
    }
}