using System;
using Domain.Common;
using Infrastructure.Persistence.Common;
using NHibernate;

namespace Infrastructure.Persistence.NHibernate
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public UnitOfWork(ISession session)
        {
            _session = session;
            _transaction = _session.BeginTransaction();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : IEntity
        {
            _session.SaveOrUpdate(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : IEntity
        {
            _session.Delete(entity);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                _transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _transaction = null;

            _session.Clear();
        }
    }
}