using Domain.Models;
using FluentValidation;

namespace Services.Validators
{
    public class EquipmentPositionHistoryValidator : AbstractValidator<EquipmentPositionHistory>
    {
        public EquipmentPositionHistoryValidator()
        {
            RuleFor(e => e.EquipmentId)
                .NotEmpty().WithMessage("Please enter the Equipment.")
                .NotNull().WithMessage("Please enter the Equipment.");
            RuleFor(e => e.Date)
                .NotNull().WithMessage("Please enter the Date.");
            RuleFor(e => e.Lat)
                .NotNull().WithMessage("Please enter the Latitude.");
            RuleFor(e => e.Lon)
                .NotNull().WithMessage("Please enter the Longitude.");
        }
    }
}
