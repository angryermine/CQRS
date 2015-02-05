using System;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Specifications.Account
{
    public class RegistrationDateRange : Specification<Entities.Account>
    {
        private readonly DateTime _from;
        private readonly DateTime _to;

        public RegistrationDateRange(DateTime from, DateTime to)
        {
            _from = from;
            _to = to;
        }

        public override Expression<Func<Entities.Account, bool>> AsExpression()
        {
            return x => x.RegistrationDate.Date >= _from && x.RegistrationDate.Date <= _to;
        }
    }
}