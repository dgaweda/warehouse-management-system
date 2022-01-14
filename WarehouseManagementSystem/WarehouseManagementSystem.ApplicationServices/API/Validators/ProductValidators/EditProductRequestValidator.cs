using DataAccess;
using DataAccess.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class EditProductRequestValidator : AbstractValidator<EditProductRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditProductRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<Product>).WithMessage("Can't edit product because it doesn't exists.");
            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.Name).NotEmpty().WithMessage("A product name can't be empty.");

            RuleFor(x => x.Barcode).NotEmpty().WithMessage("A product barcode can't be empty.");
            RuleFor(x => x.Barcode).Must(_validator.CheckIfProductBarcodeIsUnique).WithMessage(x => $"Passed barcode: {x.Barcode} already exists.");

            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now.Date.AddMonths(3)).WithMessage($"A product expiration date cannot be lower than {DateTime.Now.Date.AddMonths(3)}");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage("A product expiration date must be set.");
        }
    }
}
