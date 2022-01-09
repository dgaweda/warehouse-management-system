﻿using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.DeliveryValidators
{
    public class RemoveDeliveryRequestValidator : AbstractValidator<RemoveDeliveryRequest>
    {
        private readonly IValidatorHelper _validator;

        public RemoveDeliveryRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.DeliveryId).Must(_validator.CheckIfExist<Delivery>).WithMessage("Delivery doesn't exist.");
        }
    }
}
