using DataAccess;
using FluentValidation;
using System.Linq;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationValidator : AbstractValidator<EditLocationRequest>
    {
        private readonly WMSDatabaseContext _context;

        public EditLocationValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.Id).Must(Exist).WithMessage("Location doesn't exists.");
            RuleFor(x => x.MaxAmount).GreaterThan(0);
            RuleFor(x => x.Name).Must(CheckIfNameExists).WithMessage(x => $"Location of name: {x.Name} already exists.");
            RuleFor(x => x.Name).NotEmpty();
        }

        private bool Exist(int Id) => _context.Locations.Any(x => x.Id == Id);
        private bool CheckIfNameExists(string Name) => _context.Locations.Any(x => x.Name.Equals(Name));
    }
}
