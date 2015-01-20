using Application.Common.Queries;
using Domain.Entities;

namespace Application.Queries.Accounts
{
    public class AccountByIdContext : IQueryContext<Account>
    {
        public AccountByIdContext(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }
    }
}
