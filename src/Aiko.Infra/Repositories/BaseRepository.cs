using Aiko.Domain.Bases;
using Aiko.Domain.Interfaces;
using Aiko.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Aiko.Infra.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual TEntity? GetById(Guid id)
        {
            var query = _dbSet.Where(entity => entity.Id == id);
            return query.Any() ? query.FirstOrDefault() : null;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity).ConfigureAwait(false);
            return result.Entity;
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(Guid id)
        {
            var query = _dbSet.Find(id);
            if (query != null) _dbSet.Remove(query);
        }
    }
}
