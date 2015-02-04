using System;
using Domain.Common;

namespace Infrastructure.Persistence.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Add<TEntity>(TEntity entity) where TEntity : IEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : IEntity;
        void Commit();
        void Rollback();
    }
}