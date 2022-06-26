using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        private readonly IValidatorHelper _validator;

        public AddProductRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Barcode).Must(_validator.IsProductBarcodeUnique).WithMessage($"{ErrorType.AlreadyExist} - Product already exist");

            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now.Date.AddMonths(3)).WithMessage($"{ErrorType.BadFormat} - A product expiration date cannot be lower than {DateTime.Now.Date.AddMonths(3)}");

            RuleFor(x => x.Name).NotEmpty().WithMessage($"{ErrorType.NoContent} - A product name can't be empty.");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage($"{ErrorType.NoContent} - A product barcode can't be empty.");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage($"{ErrorType.NoContent} - A product expiration must be set.");
        }
    }
}
