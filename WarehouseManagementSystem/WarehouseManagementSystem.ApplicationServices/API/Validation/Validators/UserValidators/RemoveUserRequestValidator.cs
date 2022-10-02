using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class RemoveUserRequestValidator : AbstractValidator<RemoveUserRequest>
    {
        public RemoveUserRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.Id).Must(validator.Exist<User>).WithMessage(ErrorType.NotFound);
        }
    }
}
