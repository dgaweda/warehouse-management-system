using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.RoleValidators
{
    public class RemoveRoleRequestValidator : AbstractValidator<RemoveRoleRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveRoleRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.RoleId).Must(_validator.IsExist<DataAccess.Entities.Role>).WithMessage($"Selected role doesn't exist.");
        }
    }
}
