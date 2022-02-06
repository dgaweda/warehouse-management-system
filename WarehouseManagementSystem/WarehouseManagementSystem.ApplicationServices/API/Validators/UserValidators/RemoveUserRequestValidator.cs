using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class RemoveUserRequestValidator : AbstractValidator<RemoveUserRequest>
    {
        private readonly IValidatorHelper _validator;

        public RemoveUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.UserId).Must(_validator.CheckIfExist<User>).WithMessage("Employee doesn't exist");
        }
    }
}
