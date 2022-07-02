using Aiko.Domain.Interfaces;

namespace Aiko.Domain.Services
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseService(IBaseRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public TEntity? GetById(Guid id)
        {
            return _repository.GetById(id);
        }
        public async Task<TEntity> Create(TEntity entity)
        {
            var result = await _repository.Add(entity).ConfigureAwait(false);
            await _unitOfWork.Commit().ConfigureAwait(false);
            return result;
        }
        public async Task Update(TEntity entity)
        {
            _repository.Update(entity);
            await _unitOfWork.Commit().ConfigureAwait(false);
        }
        public async Task Delete(Guid id)
        {
            var entityDb = _repository.GetById(id);
            if (entityDb == null) return;

            _repository.Delete(id);
            await _unitOfWork.Commit().ConfigureAwait(false);
        }
    }
}
