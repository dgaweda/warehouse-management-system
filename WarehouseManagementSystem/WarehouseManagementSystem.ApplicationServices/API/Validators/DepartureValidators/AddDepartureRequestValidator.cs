using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DepartureValidators
{
    public class AddDepartureRequestValidator : AbstractValidator<AddDepartureRequest>
    {
        private readonly IValidatorHelper _validator;

        public AddDepartureRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).Must(_validator.IsDepartureNameIsUnique).WithMessage("Departure name must be unique.");
        }
    }
}
