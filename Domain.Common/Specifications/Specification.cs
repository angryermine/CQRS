using System;
using System.Linq.Expressions;
using Domain.Common.Entities;

namespace Domain.Common.Specifications
{
    public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : Entity
    {
        public abstract Expression<Func<TEntity, bool>> AsExpression();

        private class AndSpecification : Specification<TEntity>
        {
            private readonly Specification<TEntity> _left;
            private readonly Specification<TEntity> _right;

            public AndSpecification(Specification<TEntity> left, Specification<TEntity> right)
            {
                _left = left;
                _right = right;
            }

            public override Expression<Func<TEntity, bool>> AsExpression()
            {
                var param = Expression.Parameter(typeof(TEntity), "x");
                var body = Expression.AndAlso(
                    Expression.Invoke(_left.AsExpression(), param),
                    Expression.Invoke(_right.AsExpression(), param)
                    );
                return Expression.Lambda<Func<TEntity, bool>>(body, param);
            }
        }

        private class OrSpecification : Specification<TEntity>
        {
            private readonly Specification<TEntity> _left;
            private readonly Specification<TEntity> _right;

            public OrSpecification(Specification<TEntity> left, Specification<TEntity> right)
            {
                _left = left;
                _right = right;
            }

            public override Expression<Func<TEntity, bool>> AsExpression()
            {
                var param = Expression.Parameter(typeof(TEntity), "x");
                var body = Expression.OrElse(
                    Expression.Invoke(_left.AsExpression(), param),
                    Expression.Invoke(_right.AsExpression(), param)
                    );
                return Expression.Lambda<Func<TEntity, bool>>(body, param);
            }
        }

        private class NotSpecification : Specification<TEntity>
        {
            private readonly Specification<TEntity> _specification;

            public NotSpecification(Specification<TEntity> specification)
            {
                _specification = specification;
            }

            public override Expression<Func<TEntity, bool>> AsExpression()
            {
                var param = Expression.Parameter(typeof(TEntity), "x");
                var body = Expression.Not(
                    Expression.Invoke(_specification.AsExpression(), param)
                    );
                return Expression.Lambda<Func<TEntity, bool>>(body, param);
            }
        }

        public static Specification<TEntity> operator &(Specification<TEntity> left, Specification<TEntity> right)
        {
            return new AndSpecification(left, right);
        }

        public static Specification<TEntity> operator |(Specification<TEntity> left, Specification<TEntity> right)
        {
            return new OrSpecification(left, right);
        }

        public static Specification<TEntity> operator !(Specification<TEntity> specification)
        {
            return new NotSpecification(specification);
        }
    }
}