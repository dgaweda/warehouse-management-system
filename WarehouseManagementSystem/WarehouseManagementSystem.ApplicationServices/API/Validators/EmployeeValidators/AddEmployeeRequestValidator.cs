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
    public class AddEmployeeRequestValidator : AbstractValidator<AddEmployeeRequest>
    {
        private readonly IValidatorHelper<DataAccess.Entities.Role> _validator;
        public AddEmployeeRequestValidator(IValidatorHelper<DataAccess.Entities.Role> validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be specifed.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname must be specified.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role must be specified.");
            RuleFor(x => x.RoleId).Must(_validator.CheckIfExist).WithMessage("Specified Role doesn't exist.");
            RuleFor(x => x.PESEL).Length(11).WithMessage("PESEL is incorrect.");
            RuleFor(x => x.Age).ExclusiveBetween(18, 99);
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age can't be empty");
        }
    }
}
