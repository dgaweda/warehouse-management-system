using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class AuthenticateUserRequestValidator : AbstractValidator<AuthenticateUserRequest>
    {
        private readonly IValidatorHelper _validator;
        public AuthenticateUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Username).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Password).NotEmpty().WithMessage(ErrorType.NotEmpty);
        }
    }
}
