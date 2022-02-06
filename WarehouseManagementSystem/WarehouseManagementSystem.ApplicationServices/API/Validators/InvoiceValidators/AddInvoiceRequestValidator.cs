using DataAccess.Entities;
using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class AddInvoiceRequestValidator : AbstractValidator<AddInvoiceRequest>
    {
        private readonly IValidatorHelper _validator;
        public AddInvoiceRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.DeliveryId).Must(_validator.CheckIfExist<Delivery>).WithMessage("Delivery doesn't exists.");
            RuleFor(x => x.Provider).NotEmpty().WithMessage("Provider must be specified.");
            RuleFor(x => x.ReceiptDateTime.Date).LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.CreationDate.Date).LessThanOrEqualTo(y => y.ReceiptDateTime.Date).WithMessage("Creation date of invoice must be less than Receipt datetime.");
        }
    }
}
