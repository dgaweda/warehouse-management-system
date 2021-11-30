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
    public class RemoveProductRequestValidator : AbstractValidator<RemoveProductRequest>
    {
        private readonly WMSDatabaseContext _context;

        public RemoveProductRequestValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.Id).Must(CheckIfIdExists).WithMessage(x => $"Product of ID: {x.Id} doesn't exists.");
        }

        private bool CheckIfIdExists(int Id) => _context.Products.Any(x => x.Id == Id);
    }
}
