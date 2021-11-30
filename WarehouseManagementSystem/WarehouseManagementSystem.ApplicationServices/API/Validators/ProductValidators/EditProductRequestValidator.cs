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
        private readonly WMSDatabaseContext _context;
        private readonly DbSet<Product> products;
        public EditProductRequestValidator(WMSDatabaseContext context)
        {
            _context = context;
            products = _context.Set<Product>();
            RuleFor(x => x.Id).Must(CheckIfIdExists).WithMessage("Can't edit product because it doesn't exists.");
            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.Name).Must(CheckIfNameExists).WithMessage(x => $"Can't edit beacuse product of name: {x.Name} already exists.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("A product name can't be empty.");

            RuleFor(x => x.Barcode).NotEmpty().WithMessage("A product barcode can't be empty.");
            RuleFor(x => x.Barcode).Must(CheckIfBarcodeIsUnique).WithMessage(x => $"Passed barcode: {x.Barcode} already exists.");

            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now.Date.AddMonths(3)).WithMessage($"A product expiration date cannot be lower than {DateTime.Now.Date.AddMonths(3)}");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage("A product expiration date must be set.");
        }
        private bool CheckIfIdExists(int Id) => products.Any(x => x.Id == Id);

        private bool CheckIfNameExists(string name) => products.Any(x => x.Name == name);

        private bool CheckIfBarcodeIsUnique(string barcode) => products.Any(x => x.Barcode == barcode);
    }
}
