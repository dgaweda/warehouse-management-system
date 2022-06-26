using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class SetProductLocationValidator : AbstractValidator<SetProductLocationRequest>
    {
        private readonly IValidatorHelper _validator;
        public SetProductLocationValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.LocationId).Must(_validator.IsExist<Location>).WithMessage($"{ErrorType.NotFound} - Location doesn't exist");
            RuleFor(x => x.ProductId).Must(_validator.IsProductOnPalletForUnfolding).WithMessage($"{ErrorType.NotFound} - Product doesn't exists.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ErrorType.BadFormat);
            RuleFor(x => x.Amount).LessThan(x => _validator.GetLocationMaxAmount(x.LocationId)).WithMessage(x => $"{ErrorType.TooLargeData} - Amount must be less than {_validator.GetLocationMaxAmount(x.LocationId)}.");
        }
    }
}
