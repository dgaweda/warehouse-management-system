using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DepartureValidators
{
    public class GetDeparturesRequestValidator : AbstractValidator<GetDeparturesRequest>
    {
        private readonly IValidatorHelper<Departure> _validator;

        public GetDeparturesRequestValidator(IValidatorHelper<Departure> validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).Must(_validator.CheckIfDepartureNameExist).WithMessage(x => $"Departure of name: {x.Name} doesn't exist.");
        }
    }
}
