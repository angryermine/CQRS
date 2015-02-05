using System.Collections.Generic;
using Application.Common.Queries;
using Domain.Entities;
using Infrastructure.Persistence.Common;

namespace Application.Queries.AccountQueries
{
    public class AccountsPagedQuery : IQuery<IEnumerable<Account>>
    {
        public AccountsPagedQuery(int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public int CurrentPage { get; protected set; }
        public int PageSize { get; protected set; }
    }

    public class AccountsPagedQueryHandler : IQueryHandler<AccountsPagedQuery, IEnumerable<Account>>
    {
        private readonly IRepository<Account> _repository;

        public AccountsPagedQueryHandler(IRepository<Account> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Account> Execute(AccountsPagedQuery context)
        {
            return _repository
                .Paged(context.CurrentPage, context.PageSize)
                .ToList();
        }
    }
}