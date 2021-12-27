using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class GetDeliveryRequestValidator : AbstractValidator<GetDeliveriesRequest>
    {
        private readonly IValidatorHelper<Delivery> _validator;

        public GetDeliveryRequestValidator(IValidatorHelper<Delivery> validator)
        {
            _validator = validator;
            RuleFor(x => x.Name).Must(_validator.CheckIfDeliveryExist).WithMessage("Delivery doesn't exist.");
        }
    }
}
