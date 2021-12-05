using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationCurrentAmountValidator : AbstractValidator<EditLocationCurrentAmountRequest>
    {
        private readonly WMSDatabaseContext _context;
        public EditLocationCurrentAmountValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.Id).Must(Exists).WithMessage("Location doesn't exists.");
            RuleFor(x => x.CurrentAmount).GreaterThan(0).WithMessage(x => $"Current amount must be greater than {x.CurrentAmount}");
            RuleFor(x => x.CurrentAmount).LessThan(x => GetMaxFromLocation(x.Id)).WithMessage(x => $"Current amount must be less than {GetMaxFromLocation(x.Id)}.");
        }

        private bool Exists(int Id) => _context.Locations.Any(x => x.Id == Id);
        private int GetMaxFromLocation(int Id) => _context.Locations.Where(y => y.Id == Id).Select(x => x.MaxAmount).FirstOrDefault();
    }
}
