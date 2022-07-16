using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.OrderValidators
{
    public class GetOrderRequestValidator : AbstractValidator<GetOrderByIdRequest>
    {
        
        public GetOrderRequestValidator(IValidatorHelper validator)
        {
            

            RuleFor(x => x.Id).Must(validator.Exist<Order>).WithMessage(ErrorType.NotFound);
        }
    }
}