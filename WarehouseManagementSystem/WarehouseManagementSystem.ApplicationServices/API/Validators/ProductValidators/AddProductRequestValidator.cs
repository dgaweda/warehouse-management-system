using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        private readonly WMSDatabaseContext _context;

        public AddProductRequestValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.Name).Must(CheckIfNameIsUnique).WithMessage(x => $"A product of name: {x.Name} already exists.");
            RuleFor(x => x.Barcode).Must(CheckIfBarcodeIsUnique).WithMessage(x => $"A product of barcode: {x.Barcode} already exists.");

            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now.Date.AddMonths(3)).WithMessage($"A product expiration date cannot be lower than {DateTime.Now.Date.AddMonths(3)}");

            RuleFor(x => x.Name).NotEmpty().WithMessage("A product name can't be empty.");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage("A product barcode can't be empty.");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage("A product expiration must be set.");
        }

        private bool CheckIfNameIsUnique(string name) => !_context.Products.Any(x => x.Name == name);
        private bool CheckIfBarcodeIsUnique(string barcode) => !_context.Products.Any(x => x.Barcode == barcode);
    }
}
