using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Password).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage($"Maximum 30 characters.");
            RuleFor(x => x.UserName).Must(validator.IsUsernameExist).WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Email).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorType.BadFormat);
            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.PESEL).Length(11).WithMessage(ErrorType.BadFormat);
            RuleFor(x => x.Age).ExclusiveBetween(18, 99).WithMessage($"Must be greater than 18.");
            RuleFor(x => x.Age).NotEmpty().WithMessage(ErrorType.NotEmpty);
        }
    }
}
