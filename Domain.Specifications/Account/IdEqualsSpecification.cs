using System;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Specifications.Account
{
    public class IdEqualsSpecification : Specification<Entities.Account>
    {
        private readonly int _id;

        public IdEqualsSpecification(int id)
        {
            _id = id;
        }

        public override Expression<Func<Entities.Account, bool>> AsExpression()
        {
            return x => x.Id == _id;
        }
    }
}