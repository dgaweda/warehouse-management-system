using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationValidator : AbstractValidator<EditLocationRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditLocationValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.Exist<Location>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.MaxAmount).GreaterThan(0).WithMessage(ErrorType.GreaterThanZero);
            RuleFor(x => x.Name).Must(_validator.IsLocationWithThatNameExits).WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorType.NotEmpty);
        }
    }
}
