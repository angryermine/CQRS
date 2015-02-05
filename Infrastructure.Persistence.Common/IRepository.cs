using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Common;

namespace Infrastructure.Persistence.Common
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IRepository<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IRepository<TEntity> Include(Expression<Func<TEntity, object>> path);
        IRepository<TEntity> OrderByAsc(Expression<Func<TEntity, object>> path);
        IRepository<TEntity> OrderByDesc(Expression<Func<TEntity, object>> path);
        IRepository<TEntity> Paged(int page, int pageSize);
        TEntity First();
        List<TEntity> ToList();
        int Count();
    }
}