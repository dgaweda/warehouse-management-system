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
    public class EditRoleRequestValidator : AbstractValidator<EditRoleRequest>
    {
        private readonly WMSDatabaseContext _context;
        public EditRoleRequestValidator(WMSDatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Id).Must(Exist).WithMessage("Selected Role doesn't exist.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name must be filled");
            RuleFor(x => x.Name).Must(BeUnique).WithMessage("Role of that name already exists.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("You need to describe the role.");
            RuleFor(x => x.Salary).InclusiveBetween(2500, 99999).WithMessage(x => $"Salary must be equal or greater than 2500. You Entered {x.Salary}");
        }
        
        private bool BeUnique(string name) => !_context.Roles.Any(x => x.Name == name);
        private bool Exist(int id) => _context.Roles.Any(x => x.Id == id);
    }
}
