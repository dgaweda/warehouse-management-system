using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class EditDeliveryRequestValidator : AbstractValidator<EditDeliveryRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditDeliveryRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.Exist<Delivery>).WithMessage(ErrorType.NotFound);
        }
    }
}
