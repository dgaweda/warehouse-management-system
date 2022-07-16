using System;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.SeniorityValidators
{
    public class EditSeniorityRequestValidator : AbstractValidator<EditSeniorityRequest>
    {
        public EditSeniorityRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.EmploymentDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage($"Must be equal or greater than {DateTime.Now.Date}.");
            RuleFor(x => x.UserId).Must(validator.IsHiredEmployee).WithMessage(ErrorType.AlreadyExist);
        }
    }
}
