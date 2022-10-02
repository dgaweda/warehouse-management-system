using DataAccess.Entities;
using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class AddInvoiceRequestValidator : AbstractValidator<AddInvoiceRequest>
    {
        
        public AddInvoiceRequestValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.DeliveryId).Must(validator.Exist<Delivery>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Provider).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.ReceiptDateTime.Date).LessThanOrEqualTo(DateTime.Now.Date).WithMessage(ErrorType.BadFormat);
            RuleFor(x => x.CreationDate.Date).LessThanOrEqualTo(y => y.ReceiptDateTime.Date).WithMessage("Must be less than Receipt datetime.");
        }
    }
}
