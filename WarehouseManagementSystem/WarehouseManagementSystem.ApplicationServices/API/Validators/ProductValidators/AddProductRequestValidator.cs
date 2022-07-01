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
            
            RuleFor(x => x.Barcode)
                .Must(_validator.IsProductBarcodeUnique)
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
