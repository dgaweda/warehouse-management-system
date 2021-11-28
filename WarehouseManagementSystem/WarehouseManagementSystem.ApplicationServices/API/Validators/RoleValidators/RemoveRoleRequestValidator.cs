using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Role
{
    public class RemoveRoleRequestValidator : AbstractValidator<RemoveRoleRequest>
    {
        private readonly WMSDatabaseContext _context;
        public RemoveRoleRequestValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.RoleId).Must(Exist).WithMessage("Selected role doesn't exist.");
        }
        
        private bool Exist(int id) => _context.Roles.Any(x => x.Id == id);
    }
}
