using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.UserValidators
{
    public class GetUserRequestValidator : AbstractValidator<GetUsersRequest>
    {
        private readonly IValidatorHelper _validator;

        public GetUserRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.UserId).Must(_validator.IsExist<User>).WithMessage($"User doesn't exists");
        }
    }
}
