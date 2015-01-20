using System;
using System.Linq.Expressions;
using Domain.Common.Specifications;

namespace Domain.Specifications.Account
{
    public class EmailEqualsSpecification : Specification<Entities.Account>
    {
        private readonly string _email;

        public EmailEqualsSpecification(string email)
        {
            _email = email;
        }

        public override Expression<Func<Entities.Account, bool>> AsExpression()
        {
            return x => x.Email == _email;
        }
    }
}