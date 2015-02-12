using Domain.Common;
using Infrastructure.Persistence.Common;
using NHibernate;

namespace Infrastructure.Persistence.NHibernate
{
    public class Repository : IRepository
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Commit;
        }

        public IQueryBuilder<TEntity> Query<TEntity>() where TEntity : IEntity
        {
            return new QueryBuilder<TEntity>(_session);
        }
    }
}