using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class GetDeliveryRequestValidator : AbstractValidator<GetDeliveriesRequest>
    {
        private readonly IValidatorHelper _validator;

        public GetDeliveryRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).Must(_validator.IsDeliveryExist).WithMessage($"{ErrorType.NotFound} - Delivery doesn't exist.");
        }
    }
}
