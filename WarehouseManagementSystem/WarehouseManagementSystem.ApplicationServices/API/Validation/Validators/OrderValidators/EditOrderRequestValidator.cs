using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class EditOrderRequestValidator: AbstractValidator<EditOrderRequest>
    {
        
        public EditOrderRequestValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ErrorType.NotEmpty);
            
            RuleFor(x => x.Id)
                .Must(validator.Exist<Order>)
                .WithMessage(ErrorType.NotFound);
            
            RuleFor(x => x.Barcode)
                .Must(validator.IsOrderBarcodeUnique)
                .WithMessage(ErrorType.AlreadyExist);
            
            RuleFor(x => x.Barcode)
                .NotEmpty()
                .WithMessage(ErrorType.NotEmpty);
            
            RuleFor(x => x.Barcode)
                .MaximumLength(10)
                .WithMessage($"Maximum 10 chars.");
        }
    }
}