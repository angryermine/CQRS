using System;
using System.Linq.Expressions;

namespace Domain.Common
{
    public interface ISpecification<TEntity> where TEntity : IEntity
    {
        Expression<Func<TEntity, bool>> AsExpression();
    }
}