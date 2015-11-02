using Application.Common.Queries;
using Domain.Entities;
using Domain.Specifications.Account;
using Infrastructure.Persistence.Common;

namespace Application.Queries.AccountQueries
{
    public class AccountByIdQuery : IQuery<Account>
    {
        public AccountByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }
    }

    public class AccountByIdQueryHandler : IQueryHandler<AccountByIdQuery, Account>
    {
        private readonly IRepository _repository;

        public AccountByIdQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Account Execute(AccountByIdQuery context)
        {
            var spec = new AccountSpecification().WithId(context.Id);

            return _repository.Query<Account>()
                .Where(spec.AsExpression())
                .First();
        }
    }
}