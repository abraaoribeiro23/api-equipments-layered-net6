using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using FluentValidation;

namespace Services.Services
{
    public abstract class NewBaseService<TEntity, TCreateDto, TUpdateDto, TGetDto, TGetAllDto>
        : IBaseService<TEntity, TCreateDto, TUpdateDto, TGetDto, TGetAllDto>
        where TEntity : class
        where TCreateDto : class
        where TUpdateDto : class
        where TGetDto : class
        where TGetAllDto : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected NewBaseService(IBaseRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual IEnumerable<TGetAllDto> GetAll()
        {
            var entities = _repository.GetAll();
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TGetAllDto>>(entities);
        }
        public virtual TGetDto? GetById(Guid id)
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<TGetDto>(entity);
        }
        public virtual async Task<TGetDto> Create<TValidator>(TCreateDto dto) where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(dto);
            Validate(entity, Activator.CreateInstance<TValidator>());
            var result = await _repository.Add(entity).ConfigureAwait(false);
            await _unitOfWork.Commit().ConfigureAwait(false);
            return _mapper.Map<TGetDto>(result);
        }
        public virtual async Task Update<TValidator>(TUpdateDto dto) where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(dto);
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
