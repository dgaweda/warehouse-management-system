using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.EmployeeValidators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        
        private readonly IValidatorHelper _validator;
        public AddUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username must be specified.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be specified.");
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("Username is too long. Max 30 characters.");
            RuleFor(x => x.UserName).Must(_validator.CheckIfUserNameIsUnique).WithMessage("User with that username already exist.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be specified.");
            RuleFor(x => x.Email).Must(_validator.CheckEmailFormat).WithMessage("Email is incorrect.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be specifed.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname must be specified.");
            RuleFor(x => x.PESEL).Length(11).WithMessage("PESEL is incorrect.");
            RuleFor(x => x.Age).ExclusiveBetween(18, 99).WithMessage("Age must be greater than 18.");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age can't be empty");
        }
    }
}
