namespace Application.Common.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IQueryFactory _queryFactory;

        public QueryDispatcher(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public TResult Ask<TContext, TResult>(TContext context) where TContext : IQueryContext
        {
            return _queryFactory.Create<TContext, TResult>().Execute(context);
        }
    }
}