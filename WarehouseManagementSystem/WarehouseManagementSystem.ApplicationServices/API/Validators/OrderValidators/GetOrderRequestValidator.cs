using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class GetOrderRequestValidator : AbstractValidator<GetOrderByIdRequest>
    {
        private readonly IValidatorHelper _validator;
        public GetOrderRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;

            RuleFor(x => x.Id).Must(_validator.Exist<Order>).WithMessage(ErrorType.NotFound);
        }
    }
}