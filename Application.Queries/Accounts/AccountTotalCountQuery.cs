using Application.Common.Queries;
using Domain.Entities;
using Infrastructure.Persistence.Common;

namespace Application.Queries.Accounts
{
    public class AccountTotalCountQuery : IQuery<AccountsTotalCountContext, int>
    {
        private readonly IQueryBuilder<Account> _queryBuilder;

        public AccountTotalCountQuery(IQueryBuilder<Account> queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public int Execute(AccountsTotalCountContext context)
        {
            return _queryBuilder.Count();
        }
    }
}