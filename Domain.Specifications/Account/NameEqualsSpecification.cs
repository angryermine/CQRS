using System;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Specifications.Account
{
    public class NameEqualsSpecification : Specification<Entities.Account>
    {
        private readonly string _name;

        public NameEqualsSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Entities.Account, bool>> AsExpression()
        {
            return x => x.Name == _name;
        }
    }
}