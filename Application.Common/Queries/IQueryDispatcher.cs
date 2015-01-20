namespace Application.Common.Queries
{
    public interface IQueryDispatcher
    {
        TResult Ask<TContext, TResult>(TContext context) where TContext : IQueryContext;
    }
}