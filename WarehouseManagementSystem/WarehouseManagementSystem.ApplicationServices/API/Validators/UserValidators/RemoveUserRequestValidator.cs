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
    public class RemoveUserRequestValidator : AbstractValidator<RemoveUserRequest>
    {
        private readonly IValidatorHelper<User> _validator;

        public RemoveUserRequestValidator(IValidatorHelper<User> validator)
        {
            _validator = validator;
            RuleFor(x => x.UserId).Must(_validator.CheckIfExist).WithMessage("Employee doesn't exist");
        }
    }
}
