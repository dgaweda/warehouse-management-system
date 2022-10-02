using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLineValidators
{
    public class DecreaseProductAmountRequestValidator : AbstractValidator<DecreaseProductAmountRequest>
    {
        public DecreaseProductAmountRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.PalletId).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.ProductAmount).GreaterThan(0).WithMessage(ErrorType.GreaterThanZero);

            RuleFor(x => x.PalletId).Must(validator.IsPalletForUnfoldingExist).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.ProductId).Must(validator.IsProductOnPalletForUnfolding).WithMessage(ErrorType.NotFound);
        }
    }
}
