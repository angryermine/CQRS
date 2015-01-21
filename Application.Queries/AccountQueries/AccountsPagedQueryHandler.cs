using System.Collections.Generic;
using Application.Common.Queries;
using Domain.Entities;
using Infrastructure.Persistence.Common;

namespace Application.Queries.AccountQueries
{
    public class AccountsPagedQueryHandler : IQueryHandler<AccountsPagedQuery, IEnumerable<Account>>
    {
        private readonly IRepository _repository;

        public AccountsPagedQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Account> Execute(AccountsPagedQuery context)
        {
            return _repository
                .Query<Account>()
                .Paged(context.CurrentPage, context.PageSize)
                .ToList();
        }
    }
}