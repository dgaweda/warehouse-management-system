using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationCurrentAmountValidator : AbstractValidator<EditLocationCurrentAmountRequest>
    {
        private IValidatorHelper _validator;

        public EditLocationCurrentAmountValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id)
                .Must(_validator.Exist<Location>)
                .WithMessage(ErrorType.NotFound);

            RuleFor(x => x.CurrentAmount)
                .LessThan(x => _validator.GetLocationMaxAmount(x.Id))
                .WithMessage(x => $"Must be less than {_validator.GetLocationMaxAmount(x.Id)}.");
        }
    }
}
