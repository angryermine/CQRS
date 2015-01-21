using System.Collections.Generic;
using Application.Common.Queries;
using Domain.Entities;

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
}