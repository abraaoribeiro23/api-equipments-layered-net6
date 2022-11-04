using Domain.Models;
using FluentValidation;

namespace Services.Validators
{
    public class EquipmentModelValidator : AbstractValidator<EquipmentModel>
    {
        public EquipmentModelValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");
        }
    }
}
