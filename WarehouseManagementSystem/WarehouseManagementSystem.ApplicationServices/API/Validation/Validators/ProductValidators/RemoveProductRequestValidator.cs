using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class RemoveProductRequestValidator : AbstractValidator<RemoveProductRequest>
    {
        public RemoveProductRequestValidator(IValidatorHelper validator)
        {
            RuleFor(x => x.Id).Must(validator.Exist<Product>).WithMessage(ErrorType.NotFound);
        }
    }
}
