using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Seniority
{
    public class EditSeniorityRequestValidator : AbstractValidator<EditSeniorityRequest>
    {
        private readonly IValidatorHelper<DataAccess.Entities.Seniority> _validator;
        public EditSeniorityRequestValidator(IValidatorHelper<DataAccess.Entities.Seniority> validator)
        {
            _validator = validator;
            RuleFor(x => x.EmploymentDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage($"EmploymentDate must be equal or greater than {DateTime.Now.Date}.");
            RuleFor(x => x.EmployeeId).Must(_validator.CheckIfEmployeeIsNotHired).WithMessage("Employee is already hired.");
        }
    }
}
