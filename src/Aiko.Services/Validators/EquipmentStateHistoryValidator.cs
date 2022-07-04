using Aiko.Domain.Models;
using FluentValidation;

namespace Aiko.Services.Validators
{
    public class EquipmentStateHistoryValidator : AbstractValidator<EquipmentStateHistory>
    {
        public EquipmentStateHistoryValidator()
        {
            RuleFor(e => e.EquipmentId)
                .NotEmpty().WithMessage("Please enter the Equipment.")
                .NotNull().WithMessage("Please enter the Equipment.");
            RuleFor(e => e.EquipmentStateId)
                .NotEmpty().WithMessage("Please enter the Equipment State.")
                .NotNull().WithMessage("Please enter the Equipment State.");
            RuleFor(e => e.Date)
                .NotNull().WithMessage("Please enter the Date.");
        }
    }
}
