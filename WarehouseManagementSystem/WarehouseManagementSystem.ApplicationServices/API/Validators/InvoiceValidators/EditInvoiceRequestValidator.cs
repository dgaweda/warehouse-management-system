using DataAccess.Entities;
using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class EditInvoiceRequestValidator : AbstractValidator<EditInvoiceRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditInvoiceRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.Exist<Invoice>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.DeliveryId).Must(_validator.Exist<Delivery>).WithMessage(ErrorType.NotFound);
            RuleFor(x => x.Provider).NotEmpty().WithMessage(ErrorType.NotEmpty);
            RuleFor(x => x.ReceiptDateTime.Date).LessThanOrEqualTo(DateTime.Now.Date).WithMessage(ErrorType.BadFormat);
            RuleFor(x => x.CreationDate).LessThan(y => y.ReceiptDateTime).WithMessage("Must be less than Receipt datetime.");
        }
    }
}
