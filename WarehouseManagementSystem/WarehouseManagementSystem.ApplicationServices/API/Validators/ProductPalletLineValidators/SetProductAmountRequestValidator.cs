using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLine
{
    public class SetProductAmountRequestValidator : AbstractValidator<SetProductAmountRequest>
    {
        private readonly WMSDatabaseContext _context;
        public SetProductAmountRequestValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.PalletId).NotEmpty().WithMessage("This field must be filled");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product id must be filled");
            RuleFor(x => x.ProductAmount).GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PalletId).Must(ConfirmThatPalletExist).WithMessage("Pallet doesn't exist.");
            RuleFor(x => x.ProductId).Must(ConfirmThatProductExist).WithMessage("Product doesn't exist.");
        }

        private bool ConfirmThatPalletExist(int Id) => _context.ProductPalletLines.Any(x => x.PalletId == Id);
        private bool ConfirmThatProductExist(int Id) => _context.ProductPalletLines.Any(x => x.ProductId == Id);
    }
}
