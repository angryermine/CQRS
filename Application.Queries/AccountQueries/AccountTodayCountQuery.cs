using System;
using Application.Common.Queries;
using Domain.Entities;
using Domain.Specifications.Account;
using Infrastructure.Persistence.Common;

namespace Application.Queries.AccountQueries
{
    public class AccountTodayCountQuery : IQuery<int>
    {
    }

    public class AccountTodayCountQueryHandler : IQueryHandler<AccountTodayCountQuery, int>
    {
        private readonly IRepository _repository;

        public AccountTodayCountQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public int Execute(AccountTodayCountQuery context)
        {
            var spec = new AccountSpecification()
                .WithRegistrationDate(DateTime.Now.Date, DateTime.Now.Date);

            return _repository.Query<Account>()
                .Where(spec.AsExpression())
                .Count();
        }
    }
}