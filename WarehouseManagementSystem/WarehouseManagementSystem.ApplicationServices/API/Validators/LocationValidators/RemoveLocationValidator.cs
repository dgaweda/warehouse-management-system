using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class RemoveLocationValidator : AbstractValidator<RemoveLocationRequest>
    {
        private readonly IValidatorHelper _validator;

        public RemoveLocationValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<Location>).WithMessage("Location doesn't exists");
            RuleFor(x => x.Id).Must(_validator.CheckLocationCurrentAmount).WithMessage("Location still have some products");
        }
    }
}
