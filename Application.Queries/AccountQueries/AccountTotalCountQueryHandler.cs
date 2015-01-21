using Application.Common.Queries;
using Domain.Entities;
using Infrastructure.Persistence.Common;

namespace Application.Queries.AccountQueries
{
    public class AccountTotalCountQueryHandler : IQueryHandler<AccountTotalCountQuery, int>
    {
        private readonly IRepository _repository;

        public AccountTotalCountQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public int Execute(AccountTotalCountQuery context)
        {
            return _repository
                .Query<Account>()
                .Count();
        }
    }
}