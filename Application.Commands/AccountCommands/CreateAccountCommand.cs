using Application.Common.Commands;

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
}