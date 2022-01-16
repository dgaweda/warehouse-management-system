﻿using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class RemoveInvoiceRequestValidator : AbstractValidator<RemoveInvoiceRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveInvoiceRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.InvoiceId).Must(_validator.CheckIfExist<Invoice>).WithMessage(x => $"Invoice with id: {x.InvoiceId} not exists.");
        }
    }
}
