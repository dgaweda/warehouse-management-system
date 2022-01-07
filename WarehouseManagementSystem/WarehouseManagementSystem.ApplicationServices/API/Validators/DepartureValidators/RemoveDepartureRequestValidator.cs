﻿using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DepartureValidators
{
    public class RemoveDepartureRequestValidator : AbstractValidator<RemoveDepartureRequest>
    {
        private readonly IValidatorHelper<Departure> _validator;

        public RemoveDepartureRequestValidator(IValidatorHelper<Departure> validator)
        {
            _validator = validator;
            RuleFor(x => x.DepartureId).Must(_validator.CheckIfExist).WithMessage("Departure doesn't exist");
        }
    }
}