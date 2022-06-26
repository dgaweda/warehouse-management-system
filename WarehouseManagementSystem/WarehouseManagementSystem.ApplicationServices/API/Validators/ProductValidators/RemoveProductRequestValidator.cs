using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class RemoveProductRequestValidator : AbstractValidator<RemoveProductRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveProductRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.IsExist<Product>).WithMessage(x => $"Product of ID: {x.Id} doesn't exists.");
        }
    }
}
