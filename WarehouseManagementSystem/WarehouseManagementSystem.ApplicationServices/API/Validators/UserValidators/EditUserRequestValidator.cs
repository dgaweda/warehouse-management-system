using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
    {
        private readonly IValidatorHelper _validator;

        public EditUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<User>).WithMessage("User doesn't exists");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username must be specified.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be specified.");
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("Username is too long. Max 30 characters.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be specified.");
            RuleFor(x => x.Email).Must(_validator.CheckEmailFormat).WithMessage("Email is incorrect.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be specifed.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname must be specified.");
            RuleFor(x => x.PESEL).Length(11).WithMessage("PESEL is incorrect.");
            RuleFor(x => x.Age).ExclusiveBetween(18, 99);
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age can't be empty");
        }
    }
}
