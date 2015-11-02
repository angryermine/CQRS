using Application.Common.Commands;
using Domain.Entities;
using Infrastructure.Persistence.Common;

namespace Application.Commands.AccountCommands
{
    public class CreateAccountCommand : ICommand
    {
        public CreateAccountCommand(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
    }

    public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateAccountCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public void Execute(CreateAccountCommand cmd)
        {
            using (var uow = _uowFactory.Create())
            {
                uow.Add(new Account(cmd.Name, cmd.Email, cmd.Password));
                uow.Commit();
            }
        }
    }
}