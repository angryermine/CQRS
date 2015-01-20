using System;
using System.Linq.Expressions;
using Domain.Common.Specifications;

namespace Domain.Specifications.Account
{
    public class PasswordEqualsSpecification : Specification<Entities.Account>
    {
        private readonly string _password;

        public PasswordEqualsSpecification(string password)
        {
            _password = password;
        }

        public override Expression<Func<Entities.Account, bool>> AsExpression()
        {
            return x => x.Password.IsValid(_password);
        }
    }
}