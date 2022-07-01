using DataAccess.Entities;
using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class EditProductRequestValidator : AbstractValidator<EditProductRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditProductRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.Exist<Product>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorType.NotEmpty);

            RuleFor(x => x.Barcode).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Barcode).Must(_validator.IsProductBarcodeUnique).WithMessage(ErrorType.AlreadyExist);

            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now.Date.AddMonths(3)).WithMessage($"Cannot be lower than {DateTime.Now.Date.AddMonths(3)}");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage(ErrorType.NotEmpty);
        }
    }
}
