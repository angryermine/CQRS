namespace Application.Common.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IQueryFactory _queryFactory;

        public QueryDispatcher(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public TResult Ask<TResult>(IQueryContext<TResult> context)
        {
            return _queryFactory.Create<IQueryContext<TResult>, TResult>().Execute(context);
        }
    }
}