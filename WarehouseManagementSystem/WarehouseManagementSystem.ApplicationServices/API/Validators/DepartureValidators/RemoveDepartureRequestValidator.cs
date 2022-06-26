using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DepartureValidators
{
    public class RemoveDepartureRequestValidator : AbstractValidator<RemoveDepartureRequest>
    {
        private readonly IValidatorHelper _validator;

        public RemoveDepartureRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.DepartureId).Must(_validator.IsExist<Departure>).WithMessage($"{ErrorType.NotFound} - Departure doesn't exist");
        }
    }
}
