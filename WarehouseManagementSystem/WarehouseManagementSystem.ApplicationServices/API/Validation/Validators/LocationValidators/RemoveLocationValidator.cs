using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class RemoveLocationValidator : AbstractValidator<RemoveLocationRequest>
    {
        

        public RemoveLocationValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.Id).Must(validator.Exist<Location>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Id).Must(validator.IsLocationStillHaveProducts).WithMessage("Can't remove location with products.");
        }
    }
}
