﻿using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationCurrentAmountValidator : AbstractValidator<EditLocationCurrentAmountRequest>
    {
        private IValidatorHelper _validator;

        public EditLocationCurrentAmountValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id)
                .Must(_validator.CheckIfExist<Location>)
                .WithMessage("Location doesn't exists.");

            RuleFor(x => x.CurrentAmount)
                .LessThan(x => _validator.GetLocationMaxAmount(x.Id))
                .WithMessage(x => $"Current amount must be less than {_validator.GetLocationMaxAmount(x.Id)}.");
        }
    }
}
