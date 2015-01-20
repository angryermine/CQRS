namespace Infrastructure.Persistence.Common
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}