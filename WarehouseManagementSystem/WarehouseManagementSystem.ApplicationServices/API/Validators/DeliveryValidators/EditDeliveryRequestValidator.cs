using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class EditDeliveryRequestValidator : AbstractValidator<EditDeliveryRequest>
    {
        private readonly IValidatorHelper<Delivery> _validator;
        public EditDeliveryRequestValidator(IValidatorHelper<Delivery> validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist).WithMessage("Delivery doesn't exist.");
        }
    }
}
