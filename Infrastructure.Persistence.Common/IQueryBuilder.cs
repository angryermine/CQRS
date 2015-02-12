using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Common;

namespace Infrastructure.Persistence.Common
{
    public interface IQueryBuilder<TEntity> where TEntity : IEntity
    {
        IQueryBuilder<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryBuilder<TEntity> Include(Expression<Func<TEntity, object>> path);
        IQueryBuilder<TEntity> OrderByAsc(Expression<Func<TEntity, object>> path);
        IQueryBuilder<TEntity> OrderByDesc(Expression<Func<TEntity, object>> path);
        IQueryBuilder<TEntity> Paged(int page, int pageSize);
        TEntity First();
        List<TEntity> ToList();
        int Count();
    }
}