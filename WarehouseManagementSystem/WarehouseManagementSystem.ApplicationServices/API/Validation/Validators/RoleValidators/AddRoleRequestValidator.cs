using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.RoleValidators
{
    public class AddRoleRequestValidator : AbstractValidator<AddRoleRequest>
    {
        private readonly IValidatorHelper _validator;
        public AddRoleRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Name).Must(_validator.IsRoleNameUnique).WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Description).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Salary).InclusiveBetween(2500, 99999).WithMessage("Must be equal or greater than 2500.");
            RuleFor(x => x.Salary).NotEmpty().WithMessage(ErrorType.NotEmpty);
        }
    }
}
