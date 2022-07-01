using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class GetUserRequestValidator : AbstractValidator<GetUsersRequest>
    {
        private readonly IValidatorHelper _validator;

        public GetUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.UserId).Must(_validator.Exist<User>).WithMessage(ErrorType.NotFound);
        }
    }
}
