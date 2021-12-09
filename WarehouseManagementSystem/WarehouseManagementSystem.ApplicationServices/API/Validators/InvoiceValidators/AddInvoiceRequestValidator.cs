using DataAccess;
using DataAccess.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class AddInvoiceRequestValidator : AbstractValidator<AddInvoiceRequest>, IValidationForInvoice
    {
        private readonly WMSDatabaseContext _context;
        private DbSet<Invoice> _invoice;
        public AddInvoiceRequestValidator(WMSDatabaseContext context)
        {
            _context = context;
            _invoice = _context.Set<Invoice>();
            RuleFor(x => x.DeliveryId).Must(CheckIfDeliveryExists).WithMessage("Delivery doesn't exists.");
            InvoiceValidation();
        }

        public bool CheckIfDeliveryExists(int id) => _invoice.Any(x => x.DeliveryId == id);
        public bool CheckIfInvoiceExists(int id) => _invoice.Any(x => x.Id == id);
        public void InvoiceValidation()
        {
            RuleFor(x => x.Provider).NotEmpty().WithMessage("Provider must be specified.");
            RuleFor(x => x.ReceiptDateTime.Date).LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.CreationDate).LessThan(y => y.ReceiptDateTime).WithMessage("Creation date of invoice must be less than Receipt datetime.");
            RuleFor(x => x.DeliveryId).NotEmpty().WithMessage("Delivery must be specified.");
        }
    }
}
