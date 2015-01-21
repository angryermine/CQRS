namespace Application.Common.Queries
{
    public interface IQueryDispatcher
    {
        TResult Ask<TResult>(IQuery<TResult> context);
    }
}