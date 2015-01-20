using System.Collections.Generic;
using Application.Common.Queries;
using Domain.Entities;

namespace Application.Queries.Accounts
{
    public class AccountsPagedListContext : IQueryContext<IEnumerable<Account>>
    {
        public AccountsPagedListContext(int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public int CurrentPage { get; protected set; }
        public int PageSize { get; protected set; }
    }
}