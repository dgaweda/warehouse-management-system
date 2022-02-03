﻿using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DepartureValidators
{
    public class GetDeparturesRequestValidator : AbstractValidator<GetDeparturesRequest>
    {
        private readonly IValidatorHelper _validator;

        public GetDeparturesRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).Must(_validator.CheckIfDepartureNameExist).WithMessage(x => $"Departure of name: {x.Name} doesn't exist.");
        }
    }
}
