using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLine
{
    public class DecreaseProductAmountRequestValidator : AbstractValidator<DecreaseProductAmountRequest>
    {
        private readonly IValidatorHelper _validator;
        public DecreaseProductAmountRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.PalletId).NotEmpty().WithMessage("This field must be filled");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product id must be filled");
            RuleFor(x => x.ProductAmount).GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PalletId).Must(_validator.CheckIfPalletForUnfoldingExist).WithMessage("Pallet doesn't exist.");
            RuleFor(x => x.ProductId).Must(_validator.CheckIfProductIsOnPalletForUnfolding).WithMessage("Product doesn't exist.");
        }
    }
}
