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
    public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
    {
        private readonly IValidatorHelper<User> _validator;

        public GetUserRequestValidator(IValidatorHelper<User> validator)
        {
            _validator = validator;
            RuleFor(x => x.UserId).Must(_validator.CheckIfExist).WithMessage("User doesn't exists");
        }
    }
}
