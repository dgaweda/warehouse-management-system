using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class RemoveOrderRequestValidator: AbstractValidator<RemoveOrderRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveOrderRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id zamówienia nie może być puste.");
            RuleFor(x => x.Id).Must(_validator.IsExist<Order>)
                .WithMessage("Zamówienie o podanym id nie istnieje.");
        }
    }
}