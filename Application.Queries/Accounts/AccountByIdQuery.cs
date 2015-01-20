using Application.Common.Queries;
using Domain.Entities;
using Domain.Specifications.Account;
using Infrastructure.Persistence.Common;

namespace Application.Queries.Accounts
{
    public class AccountByIdQuery : IQuery<AccountByIdContext, Account>
    {
        private readonly IQueryBuilder<Account> _queryBuilder;

        public AccountByIdQuery(IQueryBuilder<Account> queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public Account Execute(AccountByIdContext context)
        {
            var spec = new AccountSpecification()
                .WithId(context.Id)
                .AsExpression();

            return _queryBuilder.Specification(spec).First();
        }
    }
}