using Domain.Common.Entities;

namespace Infrastructure.Persistence.Common
{
    public interface IRepository
    {
        IQueryBuilder<TEntity> Query<TEntity>() where TEntity : IEntity;
        void Add<TEntity>(TEntity entity) where TEntity : IEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : IEntity;
    }
}