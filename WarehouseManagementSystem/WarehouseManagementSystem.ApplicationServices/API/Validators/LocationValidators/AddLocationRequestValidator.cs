using FluentValidation;
using System.Text.RegularExpressions;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;
using Product = DataAccess.Entities.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class AddLocationRequestValidator : AbstractValidator<AddLocationRequest>
    {
        private readonly IValidatorHelper _validator;
        public AddLocationRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;

            RuleFor(x => x.Name).Must(_validator.CheckIfLocationNameIsNotTaken).WithMessage(x => $"Location named: {x.Name} already exists.");
            RuleFor(x => x.Name).Must(MatchLocationPattern).WithMessage("Name is invalid. Example location: Z.01-02");

            RuleFor(x => x.MaxAmount).ExclusiveBetween(1, 999);
            RuleFor(x => x.MaxAmount).NotEmpty().WithMessage("Max amount can't be empty");

            RuleFor(x => x.ProductId).Must(_validator.CheckIfExist<Product>).WithMessage("Product doesn't exists");
        }

        private bool MatchLocationPattern(string name)
        {
            Regex pattern = new("[A - Z][.][0][1 - 4] -[0][1 - 4]");
            if (pattern.IsMatch(name))
                return true;

            return false;
        }
    }
}
