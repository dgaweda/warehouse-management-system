﻿using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class RemoveLocationValidator : AbstractValidator<RemoveLocationRequest>
    {
        private readonly IValidatorHelper _validator;

        public RemoveLocationValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.IsExist<Location>).WithMessage("Location doesn't exists");
            RuleFor(x => x.Id).Must(_validator.IsLocationStillHaveProducts).WithMessage("Location still have some products");
        }
    }
}
