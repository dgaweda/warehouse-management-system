using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class RemoveProductRequestValidator : AbstractValidator<RemoveProductRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveProductRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.Exist<Product>).WithMessage(ErrorType.NotFound);
        }
    }
}
