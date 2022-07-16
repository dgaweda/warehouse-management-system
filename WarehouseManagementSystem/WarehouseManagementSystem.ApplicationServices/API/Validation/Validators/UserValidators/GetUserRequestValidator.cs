using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class GetUserRequestValidator : AbstractValidator<GetUsersRequest>
    {
        public GetUserRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.Id).Must(validator.Exist<User>).WithMessage(ErrorType.NotFound);
        }
    }
}
