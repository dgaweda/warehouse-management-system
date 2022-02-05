using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class GetDeliveryRequestValidator : AbstractValidator<GetDeliveriesRequest>
    {
        private readonly IValidatorHelper _validator;

        public GetDeliveryRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).Must(_validator.CheckIfDeliveryExist).WithMessage("Delivery doesn't exist.");
        }
    }
}
