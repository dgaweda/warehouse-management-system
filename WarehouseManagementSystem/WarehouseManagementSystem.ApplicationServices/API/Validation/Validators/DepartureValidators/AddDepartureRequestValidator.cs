using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DepartureValidators
{
    public class AddDepartureRequestValidator : AbstractValidator<AddDepartureRequest>
    {
        

        public AddDepartureRequestValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.Name).Must(validator.IsDepartureNameIsUnique).WithMessage(ErrorType.MustBeUnique);
        }
    }
}
