using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
    {
        private readonly IValidatorHelper _validator;

        public EditUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.Exist<User>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.UserName).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Password).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("Maximum 30 characters.");
            RuleFor(x => x.Email).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorType.BadFormat);
            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.PESEL).Length(11).WithMessage($"Must have exact 11 characters.");
            RuleFor(x => x.Age).ExclusiveBetween(18, 99);
            RuleFor(x => x.Age).NotEmpty().WithMessage(ErrorType.NotEmpty);
        }
    }
}
