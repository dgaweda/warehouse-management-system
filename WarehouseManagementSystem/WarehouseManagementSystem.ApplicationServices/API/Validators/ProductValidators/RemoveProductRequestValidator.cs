using DataAccess;
using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductValidators
{
    public class RemoveProductRequestValidator : AbstractValidator<RemoveProductRequest>
    {
        private readonly IValidatorHelper<Product> _validator;
        public RemoveProductRequestValidator(IValidatorHelper<Product> validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist).WithMessage(x => $"Product of ID: {x.Id} doesn't exists.");
        }
    }
}
