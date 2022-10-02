using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class AuthenticateUserRequestValidator : AbstractValidator<AuthenticateUserRequest>
    {
        public AuthenticateUserRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Password).NotEmpty().WithMessage(ErrorType.NotEmpty);
        }
    }
}
