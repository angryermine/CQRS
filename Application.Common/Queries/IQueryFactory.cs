namespace Application.Common.Queries
{
    public interface IQueryFactory
    {
        IQuery<TContext, TResult> Create<TContext, TResult>() where TContext : IQueryContext;
    }
}