using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class AddPalletRequestValidator : AbstractValidator<AddPalletRequest>
    {
        private readonly IValidatorHelper _validator;

        public AddPalletRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Barcode).MaximumLength(10).WithMessage("Barcode is too long.");
            RuleFor(x => x.Barcode).Must(_validator.CheckIfPalletBarcodeIsUnique).WithMessage(x => $"Pallet with barcode: {x.Barcode} already exist.");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barcode must be filled.");
            RuleFor(x => x.OrderId).Must(_validator.CheckIfExist<Order>).WithMessage("Order not exist.");
            RuleFor(x => x.DepartureId).Must(_validator.CheckIfExist<Departure>).WithMessage("Departure not exist.");
            RuleFor(x => x.InvoiceId).Must(_validator.CheckIfExist<Invoice>).WithMessage("Invoice not exist.");
            RuleFor(x => x.UserId).Must(_validator.CheckIfExist<User>).WithMessage("User not exist.");
        }
    }
}
