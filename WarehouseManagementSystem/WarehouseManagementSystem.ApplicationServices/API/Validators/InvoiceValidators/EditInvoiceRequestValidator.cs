﻿using DataAccess.Entities;
using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class EditInvoiceRequestValidator : AbstractValidator<EditInvoiceRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditInvoiceRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.IsExist<Invoice>).WithMessage(x => $"{ErrorType.NotFound} - Invoice with id: {x.Id} doesn't exists.");
            RuleFor(x => x.DeliveryId).Must(_validator.IsExist<Delivery>).WithMessage($"{ErrorType.NotFound} - Delivery doesn't exists.");
            RuleFor(x => x.Provider).NotEmpty().WithMessage($"{ErrorType.NoContent} - Provider must be specified.");
            RuleFor(x => x.ReceiptDateTime.Date).LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.CreationDate).LessThan(y => y.ReceiptDateTime).WithMessage($"{ErrorType.ValidationError} - Creation date of invoice must be less than Receipt datetime.");
        }
    }
}
