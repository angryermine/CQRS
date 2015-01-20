using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common.Entities;
using Infrastructure.Persistence.Common;
using NHibernate;
using NHibernate.Linq;

namespace Infrastructure.Persistence.NHibernate
{
    internal class QueryBuilder<TEntity> : IQueryBuilder<TEntity> where TEntity : IEntity
    {
        private IQueryable<TEntity> _session;

        public QueryBuilder(ISession session)
        {
            _session = session.Query<TEntity>();
        }

        public IQueryBuilder<TEntity> Specification(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
            {
                _session = _session.Where(predicate);
            }

            return this;
        }

        public IQueryBuilder<TEntity> Include(Expression<Func<TEntity, object>> path)
        {
            _session.Fetch(path).ToFuture();
            return this;
        }

        public IQueryBuilder<TEntity> OrderByAsc(Expression<Func<TEntity, object>> path)
        {
            _session = _session.OrderBy(path);
            return this;
        }

        public IQueryBuilder<TEntity> OrderByDesc(Expression<Func<TEntity, object>> path)
        {
            _session = _session.OrderByDescending(path);
            return this;
        }

        public IQueryBuilder<TEntity> Paged(int page, int pageSize)
        {
            _session = _session.Skip((page - 1) * pageSize).Take(pageSize);
            return this;
        }

        public TEntity First()
        {
            return _session.FirstOrDefault();
        }

        public List<TEntity> ToList()
        {
            return _session.ToList();
        }

        public int Count()
        {
            return _session.Count();
        }
    }
}