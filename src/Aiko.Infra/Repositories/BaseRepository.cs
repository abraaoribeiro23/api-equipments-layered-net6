using Aiko.Domain.Bases;
using Aiko.Domain.Interfaces;
using Aiko.Infra.Context;

namespace Aiko.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public TEntity? GetById(Guid id)
        {
            var query = _context.Set<TEntity>().Where(entity => entity.Id == id);
            return query.Any() ? query.FirstOrDefault() : null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();
            return query.ToList();
        }

        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(Guid id)
        {
            var query = _context.Set<TEntity>().Find(id);
            if (query != null) _context.Set<TEntity>().Remove(query);
        }
    }
}
