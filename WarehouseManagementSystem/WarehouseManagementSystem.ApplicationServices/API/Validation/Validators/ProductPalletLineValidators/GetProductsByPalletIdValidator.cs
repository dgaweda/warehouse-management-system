using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLineValidators
{
    public class GetProductsByPalletIdRequestValidator : AbstractValidator<GetProductsByPalletIdRequest>
    {
        public GetProductsByPalletIdRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.PalletId).Must(validator.IsPalletIdExistsInProductPalletLine)
                .WithMessage("Pallet is empty or doesn't exist.");
        }
    }
}
