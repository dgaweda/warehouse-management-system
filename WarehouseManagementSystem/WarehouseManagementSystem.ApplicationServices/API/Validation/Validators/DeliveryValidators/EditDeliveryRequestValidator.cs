using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class EditDeliveryRequestValidator : AbstractValidator<EditDeliveryRequest>
    {
        
        public EditDeliveryRequestValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.Id).Must(validator.Exist<Delivery>).WithMessage(ErrorType.NotFound);
        }
    }
}
