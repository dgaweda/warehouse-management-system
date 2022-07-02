using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class RemoveUserRequestValidator : AbstractValidator<RemoveUserRequest>
    {
        private readonly IValidatorHelper _validator;

        public RemoveUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.UserId).Must(_validator.Exist<User>).WithMessage(ErrorType.NotFound);
        }
    }
}
