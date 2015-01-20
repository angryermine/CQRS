using System.Collections.Generic;
using Application.Common.Queries;
using Domain.Entities;
using Infrastructure.Persistence.Common;

namespace Application.Queries.Accounts
{
    public class AccountsPagedListQuery : IQuery<AccountsPagedListContext, IEnumerable<Account>>
    {
        private readonly IQueryBuilder<Account> _queryBuilder; 

        public AccountsPagedListQuery(IQueryBuilder<Account> queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public IEnumerable<Account> Execute(AccountsPagedListContext context)
        {
            return _queryBuilder
                .Paged(context.CurrentPage, context.PageSize)
                .ToList();
        }
    }
}