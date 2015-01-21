namespace Application.Common.Queries
{
    public interface IQueryFactory
    {
        IQueryHandler<TContext, TResult> Create<TContext, TResult>() where TContext : IQuery<TResult>;
    }
}