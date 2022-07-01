using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.RoleValidators
{
    public class EditRoleRequestValidator : AbstractValidator<EditRoleRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditRoleRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.Exist<DataAccess.Entities.Role>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Name).Must(_validator.IsRoleNameUnique).WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Description).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Salary).InclusiveBetween(2500, 99999).WithMessage("Must be equal or greater than 2500");
        }
    }
}
