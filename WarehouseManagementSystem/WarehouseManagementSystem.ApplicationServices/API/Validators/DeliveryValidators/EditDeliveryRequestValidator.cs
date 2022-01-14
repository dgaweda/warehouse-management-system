using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class EditDeliveryRequestValidator : AbstractValidator<EditDeliveryRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditDeliveryRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<Delivery>).WithMessage("Delivery doesn't exist.");
        }
    }
}
