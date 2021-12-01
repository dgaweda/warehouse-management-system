using DataAccess;
using DataAccess.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class AddLocationRequestValidator : AbstractValidator<AddLocationRequest>
    {
        private readonly WMSDatabaseContext _context;
        private DbSet<DataAccess.Entities.Location> _locations;
        private DbSet<DataAccess.Entities.ProductPalletLine> _products;
        public AddLocationRequestValidator(WMSDatabaseContext context)
        {
            _context = context;
            _locations = context.Set<DataAccess.Entities.Location>();
            _products = context.Set<DataAccess.Entities.ProductPalletLine>();

            RuleFor(x => x.Name).Must(CheckIfExists).WithMessage(x => $"Location named: {x.Name} already exists.");
            RuleFor(x => x.Name).Must(MatchLocationPattern).WithMessage("Name is invalid. Example location: Z.01-02");

            RuleFor(x => x.MaxAmount).ExclusiveBetween(1, 999);
            RuleFor(x => x.MaxAmount).NotEmpty().WithMessage("Max amount can't be empty");

            RuleFor(x => x.ProductId).Must(CheckIfProductExists).WithMessage("Product doesn't exists");
        }

        private bool CheckIfExists(string arg) => _locations.Any(x => x.Name == arg);

        private bool MatchLocationPattern(string name)
        {
            Regex pattern = new("[A - Z][.][0][1 - 4] -[0][1 - 4]");
            if (pattern.IsMatch(name))
                return true;

            return false;
        }

        private bool CheckIfProductExists(int? id) => _products.Any(x => x.ProductId == id);
    }
}
