using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class SetProductLocationValidator : AbstractValidator<SetProductLocationRequest>
    {
        private readonly IValidatorHelper _validator;
        public SetProductLocationValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.LocationId).Must(_validator.Exist<Location>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.ProductId).Must(_validator.IsProductOnPalletForUnfolding).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ErrorType.GreaterThanZero);
            RuleFor(x => x.Amount).LessThan(x => _validator.GetLocationMaxAmount(x.LocationId)).WithMessage(x => $"Must be less than {_validator.GetLocationMaxAmount(x.LocationId)}.");
        }
    }
}
