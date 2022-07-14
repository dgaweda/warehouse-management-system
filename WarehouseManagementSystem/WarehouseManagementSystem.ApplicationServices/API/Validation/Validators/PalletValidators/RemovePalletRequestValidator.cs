﻿using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class RemovePalletRequestValidator : AbstractValidator<RemovePalletRequest>
    {
        readonly IValidatorHelper _validator;

        public RemovePalletRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.PalletId).Must(_validator.Exist<Pallet>).WithMessage(ErrorType.NotFound);
        }
    }
}