using System;
using Application.Common.Queries;
using Domain.Entities;
using Domain.Specifications.Account;
using Infrastructure.Persistence.Common;

namespace Application.Queries.AccountQueries
{
    public class AccountMonthCountQuery : IQuery<int>
    {
    }

    public class AccountMonthCountQueryHandler : IQueryHandler<AccountMonthCountQuery, int>
    {
        private readonly IRepository _repository;

        public AccountMonthCountQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public int Execute(AccountMonthCountQuery context)
        {
            var spec = new AccountSpecification()
                .WithRegistrationDate(DateTime.Now.Date.AddMonths(-1), DateTime.Now.Date);

            return _repository.Query<Account>()
                .Where(spec.AsExpression())
                .Count();
        }
    }
}