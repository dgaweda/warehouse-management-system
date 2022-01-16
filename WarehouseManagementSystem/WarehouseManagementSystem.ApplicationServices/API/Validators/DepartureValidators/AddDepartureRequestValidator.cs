using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DepartureValidators
{
    public class AddDepartureRequestValidator : AbstractValidator<AddDepartureRequest>
    {
        private readonly IValidatorHelper _validator;

        public AddDepartureRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).Must(_validator.CheckIfDepartureNameIsUnique).WithMessage("Departure name must be unique.");
        }
    }
}
