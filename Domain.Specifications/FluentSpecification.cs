using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common.Entities;
using Domain.Common.Specifications;

namespace Domain.Specifications
{
    public abstract class FluentSpecification<TEntity> : Specification<TEntity> where TEntity : Entity
    {
        private readonly List<Specification<TEntity>> _specifications;

        protected FluentSpecification()
        {
            _specifications = new List<Specification<TEntity>>();
        }

        protected void IncludeSpecification(Specification<TEntity> specification)
        {
            _specifications.Add(specification);
        }

        public override Expression<Func<TEntity, bool>> AsExpression()
        {
            if (_specifications.Any())
            {
                return _specifications.Aggregate(_specifications.First(), (current, specification) => current & specification).AsExpression();
            }

            return x => true;
        }
    }
}