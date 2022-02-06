using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class RemoveDeliveryRequestValidator : AbstractValidator<RemoveDeliveryRequest>
    {
        private readonly IValidatorHelper _validator;

        public RemoveDeliveryRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.DeliveryId).Must(_validator.CheckIfExist<Delivery>).WithMessage("Delivery doesn't exist.");
        }
    }
}
