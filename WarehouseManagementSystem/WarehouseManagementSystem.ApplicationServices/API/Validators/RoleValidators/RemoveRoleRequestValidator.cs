using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Role
{
    public class RemoveRoleRequestValidator : AbstractValidator<RemoveRoleRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveRoleRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.RoleId).Must(_validator.CheckIfExist<DataAccess.Entities.Role>).WithMessage("Selected role doesn't exist.");
        }
    }
}
