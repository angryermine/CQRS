using System;
using System.Linq.Expressions;

namespace Domain.Common
{
    public interface IFetchingStrategy<TEntity> where TEntity : IEntity
    {
        Expression<Func<TEntity>> AsExpression();
    }
}