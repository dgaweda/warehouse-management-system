using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLineValidators
{
    public class DecreaseProductAmountRequestValidator : AbstractValidator<DecreaseProductAmountRequest>
    {
        private readonly IValidatorHelper _validator;
        public DecreaseProductAmountRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.PalletId).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.ProductAmount).GreaterThan(0).WithMessage(ErrorType.GreaterThanZero);

            RuleFor(x => x.PalletId).Must(_validator.IsPalletForUnfoldingExist).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.ProductId).Must(_validator.IsProductOnPalletForUnfolding).WithMessage(ErrorType.NotFound);
        }
    }
}
