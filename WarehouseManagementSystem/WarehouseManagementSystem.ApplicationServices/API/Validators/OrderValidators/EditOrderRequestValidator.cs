using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class EditOrderRequestValidator: AbstractValidator<EditOrderRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditOrderRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id zamówienia nie może być puste.");
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<Order>)
                .WithMessage("Zamówienie o podanym id nie istnieje.");
            RuleFor(x => x.Barcode).Must(_validator.CheckIfOrderBarcodeIsUnique)
                .WithMessage("Już istnieje zamówienie o podanym numerze.");
            RuleFor(x => x.Barcode).NotEmpty()
                .WithMessage("Numer zamówienia nie może być pusty");
            RuleFor(x => x.Barcode).MaximumLength(10)
                .WithMessage("Numer zamówienia nie może mieć więcej niż 10 znaków.");
        }
    }
}