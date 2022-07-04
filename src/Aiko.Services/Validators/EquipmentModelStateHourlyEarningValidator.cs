using Aiko.Domain.Models;
using FluentValidation;

namespace Aiko.Services.Validators
{
    public class EquipmentModelStateHourlyEarningValidator : AbstractValidator<EquipmentModelStateHourlyEarning>
    {
        public EquipmentModelStateHourlyEarningValidator()
        {
            RuleFor(e => e.EquipmentModelId)
                .NotEmpty().WithMessage("Please enter the Equipment Model.")
                .NotNull().WithMessage("Please enter the Equipment Model.");
            RuleFor(e => e.EquipmentStateId)
                .NotEmpty().WithMessage("Please enter the Equipment State.")
                .NotNull().WithMessage("Please enter the Equipment State.");
        }
    }
}
