using Application.Common.Commands;
using Domain.Entities;
using Infrastructure.Persistence.Common;

namespace Application.Commands.AccountCommands
{
    public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateAccountCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public void Execute(CreateAccountCommand command)
        {
            using (var uow = _uowFactory.Create())
            {
                uow.Add(new Account(command.Email, command.Password));
                uow.Commit();
            }
        }
    }
}