using Infrastructure.Persistence.Common;
using NHibernate;

namespace Infrastructure.Persistence.NHibernate
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISession _session;

        public UnitOfWorkFactory(ISession session)
        {
            _session = session;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_session);
        }
    }
}