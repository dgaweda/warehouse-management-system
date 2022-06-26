using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class AddPalletRequestValidator : AbstractValidator<AddPalletRequest>
    {
        private readonly IValidatorHelper _validator;

        public AddPalletRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Barcode).MaximumLength(10).WithMessage("Barcode is too long.");
            RuleFor(x => x.Barcode).Must(_validator.IsPalletBarcodeIsUnique).WithMessage(x => $"Pallet with barcode: {x.Barcode} already exist.");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barcode must be filled.");
            RuleFor(x => x.OrderId).Must(_validator.IsExist<Order>).WithMessage("Order not exist.");
            RuleFor(x => x.DepartureId).Must(_validator.IsExist<Departure>).WithMessage("Departure not exist.");
            RuleFor(x => x.InvoiceId).Must(_validator.IsExist<Invoice>).WithMessage("Invoice not exist.");
            RuleFor(x => x.UserId).Must(_validator.IsExist<User>).WithMessage("User not exist.");
        }
    }
}
