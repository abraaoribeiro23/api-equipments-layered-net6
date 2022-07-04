namespace Aiko.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
