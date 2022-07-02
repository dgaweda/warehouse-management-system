using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class EditOrderRequestValidator: AbstractValidator<EditOrderRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditOrderRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ErrorType.NotEmpty);
            
            RuleFor(x => x.Id)
                .Must(_validator.Exist<Order>)
                .WithMessage(ErrorType.NotFound);
            
            RuleFor(x => x.Barcode)
                .Must(_validator.IsOrderBarcodeUnique)
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