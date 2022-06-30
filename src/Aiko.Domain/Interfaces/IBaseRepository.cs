namespace Aiko.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity? GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
