namespace Application.Common.Commands
{
    public interface ICommandDispatcher
    {
        void Send<TContext>(TContext context) where TContext : ICommandContext;
    }
}