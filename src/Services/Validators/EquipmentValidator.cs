using Domain.Models;
using FluentValidation;

namespace Services.Validators
{
    public class EquipmentValidator: AbstractValidator<Equipment>
    {
        public EquipmentValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");
            RuleFor(e => e.EquipmentModelId)
                .NotEmpty().WithMessage("Please enter the Equipment Model.")
                .NotNull().WithMessage("Please enter the Equipment Model.");
        }
    }
}
