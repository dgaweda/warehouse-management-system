using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class RemoveInvoiceRequestValidator : AbstractValidator<RemoveInvoiceRequest>
    {
        private readonly IValidationForInvoice _invoiceValidation;
        public RemoveInvoiceRequestValidator()
        {
            RuleFor(x => x.InvoiceId).Must(_invoiceValidation.CheckIfInvoiceExists).WithMessage(x => $"Invoice with id: {x.InvoiceId} not exists.");
        }
    }
}
