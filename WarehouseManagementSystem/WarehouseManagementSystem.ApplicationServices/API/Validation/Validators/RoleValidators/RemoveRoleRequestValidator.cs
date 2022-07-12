using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.RoleValidators
{
    public class RemoveRoleRequestValidator : AbstractValidator<RemoveRoleRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveRoleRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.RoleId).Must(_validator.Exist<DataAccess.Entities.Role>).WithMessage(ErrorType.NotFound);
        }
    }
}
