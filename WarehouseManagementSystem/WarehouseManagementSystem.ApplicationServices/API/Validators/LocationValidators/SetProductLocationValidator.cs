using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class SetProductLocationValidator : AbstractValidator<SetProductLocationRequest>
    {
        private readonly WMSDatabaseContext _context;

        public SetProductLocationValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.LocationId).Must(CheckIfLocationExist).WithMessage("Location doesn't exist");
            RuleFor(x => x.ProductId).Must(CheckIfProductExist).WithMessage("Product doesn't exists.");
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Amount).LessThan(x => GetMaxAmount(x.LocationId)).WithMessage(x => $"Amount must be less than {GetMaxAmount(x.LocationId)}.");
        }

        private bool CheckIfLocationExist(int Id) => _context.Locations.Any(x => x.Id == Id);
        private bool CheckIfProductExist(int Id) => _context.ProductPalletLines.Any(x => x.ProductId == Id);
        private int GetMaxAmount(int Id) => _context.Locations.Where(x => x.Id == Id).Select(x => x.MaxAmount).FirstOrDefault();
    }
}
