using System;

namespace Infrastructure.Persistence.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();

    }
}