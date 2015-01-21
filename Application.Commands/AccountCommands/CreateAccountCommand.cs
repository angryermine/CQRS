using Application.Common.Commands;

namespace Application.Commands.AccountCommands
{
    public class CreateAccountCommand : ICommand
    {
        public CreateAccountCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; protected set; }
        public string Password { get; protected set; }
    }
}