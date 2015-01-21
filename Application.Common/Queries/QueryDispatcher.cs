using System;

namespace Application.Common.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly Func<Type, object> _resolveCallback;

        public QueryDispatcher(Func<Type, object> resolveCallback)
        {
            _resolveCallback = resolveCallback;
        }

        public TResult Ask<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = _resolveCallback(handlerType);
            return (TResult)((dynamic)handler).Execute((dynamic)query);
        }
    }
}