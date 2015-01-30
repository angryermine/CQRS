using System;

namespace Application.Common.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly Func<Type, object> _resolver;

        public QueryDispatcher(Func<Type, object> resolver)
        {
            _resolver = resolver;
        }

        public TResult Ask<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            return (TResult)((dynamic) _resolver(handlerType)).Execute((dynamic)query);
        }
    }
}