using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.EmployeeValidators
{
    public class RemoveEmployeeRequestValidator : AbstractValidator<RemoveEmployeeRequest>
    {
        private readonly IValidatorHelper<Employee> _validator;

        public RemoveEmployeeRequestValidator(IValidatorHelper<Employee> validator)
        {
            _validator = validator;
            RuleFor(x => x.EmployeeId).Must(_validator.CheckIfExist).WithMessage("Employee doesn't exist");
        }
    }
}
