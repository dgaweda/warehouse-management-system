using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Seniority
{
    public class AddSeniorityRequestValidator : AbstractValidator<AddSeniorityRequest>
    {
        private readonly IValidatorHelper _validator;
        public AddSeniorityRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.EmploymentDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage($"EmploymentDate must be equal or greater than {DateTime.Now.Date}.");
            RuleFor(x => x.UserId).Must(_validator.CheckIfEmployeeIsNotHired).WithMessage("Employee is already hired.");
        }

        
    }
}
