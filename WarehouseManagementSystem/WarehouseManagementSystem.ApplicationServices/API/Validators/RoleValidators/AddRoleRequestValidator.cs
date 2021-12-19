using DataAccess;
using FluentValidation;
using System.Linq;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Role
{
    public class AddRoleRequestValidator : AbstractValidator<AddRoleRequest>
    {
        private readonly IValidatorHelper<DataAccess.Entities.Role> _validator;
        public AddRoleRequestValidator(IValidatorHelper<DataAccess.Entities.Role> validator)
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name must be filled");
            RuleFor(x => x.Name).Must(BeUnique).WithMessage("Role of that name already exists.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("You need to describe the role.");
            RuleFor(x => x.Salary).InclusiveBetween(2500, 99999).WithMessage(x => $"Salary must be equal or greater than 2500. You Entered {x.Salary}");   
        }

        private bool BeUnique(string name) => !_context.Roles.Any(x => x.Name == name);
    }
}
