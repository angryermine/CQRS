namespace Application.Common.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandFactory _commandFactory;

        public CommandDispatcher(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Send<TContext>(TContext context) where TContext : ICommandContext
        {
            _commandFactory.Create<TContext>().Execute(context);
        }
    }
}