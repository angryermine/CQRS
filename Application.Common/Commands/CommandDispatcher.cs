using System;

namespace Application.Common.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Func<Type, object> _resolver;

        public CommandDispatcher(Func<Type, object> resolver)
        {
            _resolver = resolver;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>) _resolver(typeof(ICommandHandler<TCommand>));
            handler.Execute(command);
        }
    }
}