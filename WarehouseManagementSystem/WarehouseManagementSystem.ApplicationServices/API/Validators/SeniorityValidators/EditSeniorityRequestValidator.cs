using System;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.SeniorityValidators
{
    public class EditSeniorityRequestValidator : AbstractValidator<EditSeniorityRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditSeniorityRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.EmploymentDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage($"EmploymentDate must be equal or greater than {DateTime.Now.Date}.");
            RuleFor(x => x.UserId).Must(_validator.IsHiredEmployee).WithMessage("Employee is already hired.");
        }
    }
}
