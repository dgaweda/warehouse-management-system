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
            RuleFor(x => x.Id).Must(_validator.IsExist<Pallet>).WithMessage($"Pallet of that Id not exist.");
            RuleFor(x => x.OrderId).Must(_validator.IsExist<Order>).WithMessage($"Order not exist.");
            RuleFor(x => x.DepartureId).Must(_validator.IsExist<Departure>).WithMessage($"Departure not exist.");
            RuleFor(x => x.InvoiceId).Must(_validator.IsExist<Invoice>).WithMessage($"Invoice not exist.");
            RuleFor(x => x.UserId).Must(_validator.IsExist<User>).WithMessage($"User not exist.");
        }
    }
}
