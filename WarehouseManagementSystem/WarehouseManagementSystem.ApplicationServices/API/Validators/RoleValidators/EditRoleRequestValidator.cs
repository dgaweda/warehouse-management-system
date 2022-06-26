using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.RoleValidators
{
    public class EditRoleRequestValidator : AbstractValidator<EditRoleRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditRoleRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.IsExist<DataAccess.Entities.Role>).WithMessage("Selected Role doesn't exist.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name must be filled");
            RuleFor(x => x.Name).Must(_validator.IsRoleNameIsUnique).WithMessage("Role of that name already exists.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("You need to describe the role.");
            RuleFor(x => x.Salary).InclusiveBetween(2500, 99999).WithMessage(x => $"Salary must be equal or greater than 2500. You Entered {x.Salary}");
        }
    }
}
