using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.RoleValidators
{
    public class RemoveRoleRequestValidator : AbstractValidator<RemoveRoleRequest>
    {
        public RemoveRoleRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.RoleId).Must(validator.Exist<DataAccess.Entities.Role>).WithMessage(ErrorType.NotFound);
        }
    }
}
