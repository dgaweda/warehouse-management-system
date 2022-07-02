using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class RemoveDeliveryRequestValidator : AbstractValidator<RemoveDeliveryRequest>
    {
        private readonly IValidatorHelper _validator;

        public RemoveDeliveryRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.DeliveryId).Must(_validator.Exist<Delivery>).WithMessage(ErrorType.NotFound);
        }
    }
}
