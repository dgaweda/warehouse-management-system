using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class SetPalletDestinationRequestValidator : AbstractValidator<SetPalletDestinationRequest>
    {
        readonly IValidatorHelper _validator;

        public SetPalletDestinationRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<Pallet>).WithMessage("Pallet of that Id not exist.");
            RuleFor(x => x.OrderId).Must(_validator.CheckIfExist<Order>).WithMessage("Order not exist.");
            RuleFor(x => x.DepartureId).Must(_validator.CheckIfExist<Departure>).WithMessage("Departure not exist.");
            RuleFor(x => x.InvoiceId).Must(_validator.CheckIfExist<Invoice>).WithMessage("Invoice not exist.");
            RuleFor(x => x.UserId).Must(_validator.CheckIfExist<User>).WithMessage("User not exist.");
        }
    }
}
