using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.EmployeeValidators
{
    public class GetEmployeeRequestValidator : AbstractValidator<GetEmployeesRequest>
    {
        private readonly IValidatorHelper<Employee> _validator;

        public GetEmployeeRequestValidator(IValidatorHelper<Employee> validator)
        {
            _validator = validator;
            RuleFor(x => x.EmployeeId).Must(_validator.CheckIfExist).WithMessage("Employee doesn't exists");
        }
    }
}
