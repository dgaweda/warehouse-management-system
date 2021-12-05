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
    public class RemoveLocationValidator : AbstractValidator<RemoveLocationRequest>
    {
        private readonly WMSDatabaseContext _context;

        public RemoveLocationValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.Id).Must(CheckIfExist).WithMessage("Location doesn't exists");
        }

        private bool CheckIfExist(int Id) => _context.Locations.Any(x => x.Id == Id);
    }
}
