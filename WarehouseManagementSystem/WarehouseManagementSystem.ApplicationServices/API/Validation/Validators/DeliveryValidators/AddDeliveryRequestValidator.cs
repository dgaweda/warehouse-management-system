using System;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Validation;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class AddDeliveryRequestValidator : AbstractValidator<AddDeliveryRequest>
    {
        public AddDeliveryRequestValidator()
        {
            RuleFor(x => x.Arrival).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.Arrival).LessThan(DateTime.Now).WithMessage(ErrorType.BadFormat);
        }
    }
}
