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
        private readonly IValidatorHelper _validator;
        public RemoveRoleRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.RoleId).Must(_validator.CheckIfExist<DataAccess.Entities.Role>).WithMessage("Selected role doesn't exist.");
        }
    }
}
