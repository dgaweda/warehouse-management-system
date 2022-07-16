using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationCurrentAmountValidator : AbstractValidator<EditLocationCurrentAmountRequest>
    {

        public EditLocationCurrentAmountValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.Id)
                .Must(validator.Exist<Location>)
                .WithMessage(ErrorType.NotFound);

            RuleFor(x => x.CurrentAmount)
                .LessThan(x => validator.GetLocationMaxAmount(x.Id))
                .WithMessage(x => $"Must be less than {validator.GetLocationMaxAmount(x.Id)}.");
        }
    }
}
