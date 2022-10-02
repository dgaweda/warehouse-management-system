using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class AddOrderRequestValidator: AbstractValidator<AddOrderRequest>
    {
        
        public AddOrderRequestValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.Barcode).Must(validator.IsOrderBarcodeUnique)
                .WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Barcode).NotEmpty()
                .WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Barcode).MaximumLength(10)
                .WithMessage($"Maximum 10 chars.");
            RuleFor(x => x.OrderLines).NotEmpty()
                .WithMessage(ErrorType.NotEmpty);
        }
    }
}