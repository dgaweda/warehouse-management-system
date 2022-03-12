using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class AddOrderRequestValidator: AbstractValidator<AddOrderRequest>
    {
        private readonly IValidatorHelper _validator;
        public AddOrderRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Barcode).Must(_validator.CheckIfOrderBarcodeIsUnique)
                .WithMessage("Już istnieje zamówienie o podanym numerze.");
            RuleFor(x => x.Barcode).NotEmpty()
                .WithMessage("Numer zamówienia nie może być pusty");
            RuleFor(x => x.Barcode).MaximumLength(10)
                .WithMessage("Numer zamówienia nie może mieć więcej niż 10 znaków.");
            RuleFor(x => x.OrderLines).NotEmpty()
                .WithMessage("Zamówienie nie może być puste.");
        }
    }
}