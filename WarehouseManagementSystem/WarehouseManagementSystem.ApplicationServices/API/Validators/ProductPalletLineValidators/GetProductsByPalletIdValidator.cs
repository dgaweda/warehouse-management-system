using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLineValidators
{
    public class GetProductsByPalletIdRequestValidator : AbstractValidator<GetProductsByPalletIdRequest>
    {
        private readonly IValidatorHelper _validator;
        public GetProductsByPalletIdRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.PalletId)
                .NotEmpty()
                .Custom((value, context) =>
                {
                    var exist = _validator.IsPalletIdExistsInProductPalletLine(value);
                    if (!exist)
                    {
                        context.AddFailure("Pallet is probably empty or doesn't exist.");
                    }
                });
        }
    }
}
