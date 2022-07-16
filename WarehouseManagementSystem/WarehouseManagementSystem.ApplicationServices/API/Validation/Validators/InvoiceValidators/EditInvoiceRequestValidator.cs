using DataAccess.Entities;
using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class EditInvoiceRequestValidator : AbstractValidator<EditInvoiceRequest>
    {
        
        public EditInvoiceRequestValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.Id).Must(validator.Exist<Invoice>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.DeliveryId).Must(validator.Exist<Delivery>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Provider).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.ReceiptDateTime.Date).LessThanOrEqualTo(DateTime.Now.Date).WithMessage(ErrorType.BadFormat);
            RuleFor(x => x.CreationDate).LessThan(y => y.ReceiptDateTime).WithMessage("Must be less than Receipt datetime.");
        }
    }
}
