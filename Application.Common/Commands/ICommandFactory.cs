namespace Application.Common.Commands
{
    public interface ICommandFactory
    {
        ICommand<TContext> Create<TContext>() where TContext : ICommandContext;
    }
}