using DataAccess.Entities;
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
        private readonly ICustomValidator _validator;
        public RemoveInvoiceRequestValidator(ICustomValidator validator)
        {
            _validator = validator;
            RuleFor(x => x.InvoiceId).Must(_validator.CheckIfExist<Invoice>).WithMessage(x => $"Invoice with id: {x.InvoiceId} not exists.");
        }
    }
}
