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
    public class AddDepartureRequestValidator : AbstractValidator<AddDepartureRequest>
    {
        private readonly IValidatorHelper<Departure> _validator;

        public AddDepartureRequestValidator(IValidatorHelper<Departure> validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).Must(_validator.CheckIfDepartureNameIsUnique).WithMessage("Departure name must be unique.");
        }
    }
}
