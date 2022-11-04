namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity? GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        Task<TEntity> Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
