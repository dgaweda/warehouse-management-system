using System.Net;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLineValidators
{
    public class GetProductsByPalletIdRequestValidator : AbstractValidator<GetProductsByPalletIdRequest>
    {
        private readonly IValidatorHelper _validator;
        public GetProductsByPalletIdRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.PalletId).Must(_validator.IsPalletIdExistsInProductPalletLine)
                .WithMessage($"{ErrorType.NotFound} - Pallet is empty or doesn't exist.");
        }
    }
}
