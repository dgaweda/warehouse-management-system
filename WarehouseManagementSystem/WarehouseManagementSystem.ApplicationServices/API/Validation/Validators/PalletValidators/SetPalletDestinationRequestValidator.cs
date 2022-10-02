using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class SetPalletDestinationRequestValidator : AbstractValidator<SetPalletDestinationRequest>
    {
        public SetPalletDestinationRequestValidator(IValidatorHelper validator)
        {
            var validator1 = validator;
            RuleFor(x => x.Id).Must(validator1.Exist<Pallet>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.OrderId).Must(validator1.Exist<Order>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.DepartureId).Must(validator1.Exist<Departure>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.InvoiceId).Must(validator1.Exist<Invoice>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.UserId).Must(validator1.Exist<User>).WithMessage(ErrorType.NotFound);
        }
    }
}
