namespace Application.Common.Queries
{
    public interface IQueryHandler<in TContext, out TResult> where TContext : IQuery<TResult>
    {
        TResult Execute(TContext context);
    }
}