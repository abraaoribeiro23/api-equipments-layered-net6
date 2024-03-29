﻿using Domain.Models;
using FluentValidation;

namespace Services.Validators
{
    public class EquipmentStateValidator: AbstractValidator<EquipmentState>
    {
        public EquipmentStateValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");
        }
    }
}
