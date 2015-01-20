namespace Application.Common.Queries
{
    public interface IQuery<in TContext, out TResult>
    {
        TResult Execute(TContext context);
    }
}