using System;
using System.Linq.Expressions;
using Domain.Common.Entities;

namespace Domain.Common.Specifications
{
    public interface ISpecification<TEntity> where TEntity : IEntity
    {
        Expression<Func<TEntity, bool>> AsExpression();
    }
}