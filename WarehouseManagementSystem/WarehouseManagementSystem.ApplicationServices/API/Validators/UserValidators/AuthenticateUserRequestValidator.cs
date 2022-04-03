using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class AuthenticateUserRequestValidator : AbstractValidator<AuthenticateUserRequest>
    {
        private readonly IValidatorHelper _validator;
        public AuthenticateUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username must be specified.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be specified.");
            RuleFor(x => x.Username).Must(_validator.CheckIfUsernameExist).WithMessage("User of that username doesn't exist.");
            
        }
    }
}
