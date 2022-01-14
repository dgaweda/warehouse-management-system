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
    public class EditInvoiceRequestValidator : AbstractValidator<EditInvoiceRequest>
    {
        private readonly IValidatorHelper _validator;
        public EditInvoiceRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist<Invoice>).WithMessage(x => $"Invoice with id: {x.Id} doesn't exists.");
            RuleFor(x => x.DeliveryId).Must(_validator.CheckIfExist<Delivery>).WithMessage("Delivery doesn't exists.");
            RuleFor(x => x.Provider).NotEmpty().WithMessage("Provider must be specified.");
            RuleFor(x => x.ReceiptDateTime.Date).LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.CreationDate).LessThan(y => y.ReceiptDateTime).WithMessage("Creation date of invoice must be less than Receipt datetime.");
        }
    }
}
