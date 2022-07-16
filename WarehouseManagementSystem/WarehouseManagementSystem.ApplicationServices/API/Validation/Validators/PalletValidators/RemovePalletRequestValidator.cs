using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class RemovePalletRequestValidator : AbstractValidator<RemovePalletRequest>
    {
        public RemovePalletRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.Id).Must(validator.Exist<Pallet>).WithMessage(ErrorType.NotFound);
        }
    }
}
