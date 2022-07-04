using FluentValidation;

namespace Aiko.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(Guid id);
        Task<TEntity> Create<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        Task Update<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        Task Delete(Guid id);
        void Validate(TEntity obj, AbstractValidator<TEntity> validator);
    }
}