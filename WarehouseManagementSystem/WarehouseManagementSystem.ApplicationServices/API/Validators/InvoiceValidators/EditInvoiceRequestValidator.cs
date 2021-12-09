using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class EditInvoiceRequestValidator : AbstractValidator<EditInvoiceRequest>
    {
        private readonly IValidationForInvoice _invoiceValidator;
        public EditInvoiceRequestValidator()
        {
            RuleFor(x => x.Id).Must(_invoiceValidator.CheckIfInvoiceExists).WithMessage(x => $"Invoice with id: {x.Id} doesn't exists.");
            RuleFor(x => x.DeliveryId).Must(_invoiceValidator.CheckIfDeliveryExists).WithMessage("Delivery doesn't exists.");
            _invoiceValidator.InvoiceValidation();
        }
    }
}
