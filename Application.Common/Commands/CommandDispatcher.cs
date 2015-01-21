using System;

namespace Application.Common.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Func<Type, object> _resolveCallback;

        public CommandDispatcher(Func<Type, object> resolveCallback)
        {
            _resolveCallback = resolveCallback;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)_resolveCallback(typeof(ICommandHandler<TCommand>));
            handler.Execute(command);
        }
    }
}