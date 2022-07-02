using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class AddPalletRequestValidator : AbstractValidator<AddPalletRequest>
    {
        private readonly IValidatorHelper _validator;

        public AddPalletRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Barcode).MaximumLength(10).WithMessage($"Maximum 10 characters.");
            RuleFor(x => x.Barcode).Must(_validator.IsPalletBarcodeIsUnique).WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Barcode).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.OrderId).Must(_validator.Exist<Order>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.DepartureId).Must(_validator.Exist<Departure>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.InvoiceId).Must(_validator.Exist<Invoice>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.UserId).Must(_validator.Exist<User>).WithMessage(ErrorType.NotFound);
        }
    }
}
