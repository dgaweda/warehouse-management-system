using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class SetProductLocationValidator : AbstractValidator<SetProductLocationRequest>
    {
        
        public SetProductLocationValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.LocationId).Must(validator.Exist<Location>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.ProductId).Must(validator.IsProductOnPalletForUnfolding).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ErrorType.GreaterThanZero);
            RuleFor(x => x.Amount).LessThan(x => validator.GetLocationMaxAmount(x.LocationId)).WithMessage(x => $"Must be less than {validator.GetLocationMaxAmount(x.LocationId)}.");
        }
    }
}
