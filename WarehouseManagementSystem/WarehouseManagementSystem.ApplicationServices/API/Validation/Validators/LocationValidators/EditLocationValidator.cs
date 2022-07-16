using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationValidator : AbstractValidator<EditLocationRequest>
    {
        
        public EditLocationValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.Id).Must(validator.Exist<Location>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.MaxAmount).GreaterThan(0).WithMessage(ErrorType.GreaterThanZero);
            RuleFor(x => x.Name).Must(validator.IsLocationWithThatNameExits).WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorType.NotEmpty);
        }
    }
}
