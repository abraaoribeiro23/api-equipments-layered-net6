using FluentValidation;

namespace Aiko.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity, in TCreateDto, in TUpdateDto, TGetDto, out TGetAllDto>
        where TEntity : class
        where TCreateDto : class
        where TUpdateDto : class
        where TGetDto : class
        where TGetAllDto : class
    {
        IEnumerable<TGetAllDto> GetAll();
        TGetDto? GetById(Guid id);
        Task<TGetDto> Create<TValidator>(TCreateDto dto) where TValidator : AbstractValidator<TEntity>;
        Task Update<TValidator>(TUpdateDto dto) where TValidator : AbstractValidator<TEntity>;
        Task Delete(Guid id);
        void Validate(TEntity obj, AbstractValidator<TEntity> validator);
    }
}