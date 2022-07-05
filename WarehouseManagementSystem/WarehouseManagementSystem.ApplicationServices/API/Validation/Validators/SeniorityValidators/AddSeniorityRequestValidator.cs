using System;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.SeniorityValidators
{
    public class AddSeniorityRequestValidator : AbstractValidator<AddSeniorityRequest>
    {
        private readonly IValidatorHelper _validator;
        public AddSeniorityRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.EmploymentDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage($"Must be equal or greater than {DateTime.Now.Date}.");
            RuleFor(x => x.UserId).Must(_validator.IsHiredEmployee).WithMessage(ErrorType.AlreadyExist);
        }

        
    }
}
