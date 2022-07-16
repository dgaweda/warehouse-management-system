using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class AddPalletRequestValidator : AbstractValidator<AddPalletRequest>
    {
        public AddPalletRequestValidator(IValidatorHelper validator)
        {
            var validator1 = validator;
            RuleFor(x => x.Barcode).MaximumLength(10).WithMessage($"Maximum 10 characters.");
            RuleFor(x => x.Barcode).Must(validator1.IsPalletBarcodeIsUnique).WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Barcode).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.OrderId).Must(validator1.Exist<Order>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.DepartureId).Must(validator1.Exist<Departure>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.InvoiceId).Must(validator1.Exist<Invoice>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.UserId).Must(validator1.Exist<User>).WithMessage(ErrorType.NotFound);
        }
    }
}
