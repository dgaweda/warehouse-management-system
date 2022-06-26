using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class AddOrderRequestValidator: AbstractValidator<AddOrderRequest>
    {
        private readonly IValidatorHelper _validator;
        public AddOrderRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Barcode).Must(_validator.IsOrderBarcodeIsUnique)
                .WithMessage($"{ErrorType.AlreadyExist} - Order already exist.");
            RuleFor(x => x.Barcode).NotEmpty()
                .WithMessage($"{ErrorType.NoContent} - Barcode can't be empty.");
            RuleFor(x => x.Barcode).MaximumLength(10)
                .WithMessage($"{ErrorType.TooLargeData} - Barcode can have maximum 10 chars.");
            RuleFor(x => x.OrderLines).NotEmpty()
                .WithMessage($"{ErrorType.NoContent} - Orderline can't be empty.");
        }
    }
}