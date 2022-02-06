using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class EditLocationValidator : AbstractValidator<EditLocationRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditLocationValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<Location>).WithMessage("Location doesn't exists.");
            RuleFor(x => x.MaxAmount).GreaterThan(0);
            RuleFor(x => x.Name).Must(_validator.CheckIfLocationNameIsNotTaken).WithMessage(x => $"Location of name: {x.Name} already exists.");
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
