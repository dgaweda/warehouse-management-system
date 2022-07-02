using FluentValidation;
using System.Text.RegularExpressions;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
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

            RuleFor(x => x.Name).Must(_validator.IsLocationWithThatNameExits).WithMessage(ErrorType.AlreadyExist);
            RuleFor(x => x.Name).Must(MatchLocationPattern).WithMessage($"Invalid location name. Example location: Z.01-02");
            RuleFor(x => x.MaxAmount).ExclusiveBetween(1, 999);
            RuleFor(x => x.MaxAmount).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.ProductId).Must(_validator.Exist<Product>).WithMessage(ErrorType.NotFound);
        }

        private bool MatchLocationPattern(string name)
        {
            Regex pattern = new("[A - Z][.][0][1 - 4] -[0][1 - 4]");
            return pattern.IsMatch(name);
        }
    }
}
