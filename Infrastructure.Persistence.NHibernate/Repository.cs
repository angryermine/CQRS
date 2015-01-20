using System;
using Domain.Common.Entities;
using Infrastructure.Persistence.Common;
using NHibernate;

namespace Infrastructure.Persistence.NHibernate
{
    public class Repository : IRepository
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Commit;
        }

        public IQueryBuilder<TEntity> Query<TEntity>() where TEntity : IEntity
        {
            return new QueryBuilder<TEntity>(_session);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : IEntity
        {
            if (!_session.Transaction.IsActive) throw new Exception("Open Session Transaction!");

            _session.SaveOrUpdate(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : IEntity
        {
            if (!_session.Transaction.IsActive) throw new Exception("Open Session Transaction!");

            _session.Delete(entity);
        }
    }
}