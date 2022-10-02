using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DepartureValidators
{
    public class RemoveDepartureRequestValidator : AbstractValidator<RemoveDepartureRequest>
    {
        

        public RemoveDepartureRequestValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.Id).Must(validator.Exist<Departure>).WithMessage(ErrorType.NotFound);
        }
    }
}
