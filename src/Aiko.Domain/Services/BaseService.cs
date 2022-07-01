using Aiko.Domain.Bases;
using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

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
        public TEntity Create(TEntity entity)
        {
            var result = _repository.Add(entity);
            _unitOfWork.Commit();
            return result;
        }
        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
        public void Delete(Guid id)
        {
            var entityDb = _repository.GetById(id);
            if (entityDb == null) return;

            _repository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
