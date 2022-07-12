using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class SetPalletDestinationRequestValidator : AbstractValidator<SetPalletDestinationRequest>
    {
        readonly IValidatorHelper _validator;

        public SetPalletDestinationRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.Exist<Pallet>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.OrderId).Must(_validator.Exist<Order>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.DepartureId).Must(_validator.Exist<Departure>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.InvoiceId).Must(_validator.Exist<Invoice>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.UserId).Must(_validator.Exist<User>).WithMessage(ErrorType.NotFound);
        }
    }
}
