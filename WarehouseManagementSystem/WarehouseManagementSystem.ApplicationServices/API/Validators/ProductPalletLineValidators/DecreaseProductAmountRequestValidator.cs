using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLineValidators
{
    public class DecreaseProductAmountRequestValidator : AbstractValidator<DecreaseProductAmountRequest>
    {
        private readonly IValidatorHelper _validator;
        public DecreaseProductAmountRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.PalletId).NotEmpty().WithMessage($"{ErrorType.NoContent} - This field must be filled");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage($"{ErrorType.NoContent} - Product id must be filled");
            RuleFor(x => x.ProductAmount).GreaterThan(0).WithMessage($"{ErrorType.BadFormat} - Amount must be greater than 0.");

            RuleFor(x => x.PalletId).Must(_validator.IsPalletForUnfoldingExist).WithMessage($"{ErrorType.NotFound} - Pallet doesn't exist.");
            RuleFor(x => x.ProductId).Must(_validator.IsProductOnPalletForUnfolding).WithMessage($"{ErrorType.NotFound} - Product doesn't exist.");
        }
    }
}
