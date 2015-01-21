using Application.Common.Commands;
using Domain.Entities;
using Infrastructure.Persistence.Common;

namespace Application.Commands.AccountCommands
{
    public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand>
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IRepository _repository;

        public CreateAccountCommandHandler(IUnitOfWorkFactory uowFactory, IRepository repository)
        {
            _uowFactory = uowFactory;
            _repository = repository;
        }

        public void Execute(CreateAccountCommand command)
        {
            using (var uow = _uowFactory.Create())
            {
                _repository.Add(new Account(command.Email, command.Password));
                uow.Commit();
            }
        }
    }
}