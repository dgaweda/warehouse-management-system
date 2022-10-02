using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.Barcode)
                .Must(validator.IsProductBarcodeUnique)
                .WithMessage(ErrorType.AlreadyExist);

            RuleFor(x => x.ExpirationDate)
                .GreaterThan(DateTime.Now.Date.AddMonths(3))
                .WithMessage($"Cannot be lower than {DateTime.Now.Date.AddMonths(3)}");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ErrorType.NotEmpty);
            
            RuleFor(x => x.Barcode)
                .NotEmpty()
                .WithMessage(ErrorType.NotEmpty);
            
            RuleFor(x => x.ExpirationDate)
                .NotEmpty()
                .WithMessage(ErrorType.NotEmpty);
        }
    }
}
