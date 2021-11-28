using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Seniority
{
    public class AddSeniorityRequestValidator : AbstractValidator<AddSeniorityRequest>
    {
        private readonly WMSDatabaseContext _context;
        public AddSeniorityRequestValidator(WMSDatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.EmploymentDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage($"EmploymentDate must be equal or greater than {DateTime.Now.Date}.");
            RuleFor(x => x.EmployeeId).Must(BeUnique).WithMessage("EmployeeID must be Unique.");
        }

        public bool BeUnique(int employeeId) => _context.Seniorities.Any(x => x.EmployeeId == employeeId);
    }
}
