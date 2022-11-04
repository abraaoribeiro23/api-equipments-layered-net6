using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using FluentValidation;

namespace Services.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseService(IBaseRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual TEntity? GetById(Guid id)
        {
            return _repository.GetById(id);
        }
        public virtual async Task<TEntity> Create<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
            var result = await _repository.Add(entity).ConfigureAwait(false);
            await _unitOfWork.Commit().ConfigureAwait(false);
            return result;
        }
        public virtual async Task Update<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
            _repository.Update(entity);
            await _unitOfWork.Commit().ConfigureAwait(false);
        }
        public virtual async Task Delete(Guid id)
        {
            var entityDb = _repository.GetById(id);
            if (entityDb == null) return;

            _repository.Delete(id);
            await _unitOfWork.Commit().ConfigureAwait(false);
        }

        public void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
