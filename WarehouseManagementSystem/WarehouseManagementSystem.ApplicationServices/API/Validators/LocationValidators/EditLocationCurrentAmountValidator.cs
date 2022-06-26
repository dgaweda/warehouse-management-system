using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationCurrentAmountValidator : AbstractValidator<EditLocationCurrentAmountRequest>
    {
        private IValidatorHelper _validator;

        public EditLocationCurrentAmountValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id)
                .Must(_validator.IsExist<Location>)
                .WithMessage($"{ErrorType.NotFound} - Location doesn't exists.");

            RuleFor(x => x.CurrentAmount)
                .LessThan(x => _validator.GetLocationMaxAmount(x.Id))
                .WithMessage(x => $"{ErrorType.TooLargeData} - Current amount must be less than {_validator.GetLocationMaxAmount(x.Id)}.");
        }
    }
}
