using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Role
{
    public class EditRoleRequestValidator : AbstractValidator<EditRoleRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditRoleRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<DataAccess.Entities.Role>).WithMessage("Selected Role doesn't exist.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name must be filled");
            RuleFor(x => x.Name).Must(_validator.CheckIfRoleNameIsUnique).WithMessage("Role of that name already exists.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("You need to describe the role.");
            RuleFor(x => x.Salary).InclusiveBetween(2500, 99999).WithMessage(x => $"Salary must be equal or greater than 2500. You Entered {x.Salary}");
        }
    }
}
