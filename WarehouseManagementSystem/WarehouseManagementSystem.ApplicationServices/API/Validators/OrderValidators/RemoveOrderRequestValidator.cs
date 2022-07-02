using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class RemoveOrderRequestValidator: AbstractValidator<RemoveOrderRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveOrderRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Id).Must(_validator.Exist<Order>)
                .WithMessage(ErrorType.NotFound);
        }
    }
}