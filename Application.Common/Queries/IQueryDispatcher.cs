namespace Application.Common.Queries
{
    public interface IQueryDispatcher
    {
        TResult Ask<TResult>(IQueryContext<TResult> query);
    }
}