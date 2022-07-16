using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Validation;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class RemoveInvoiceRequestValidator : AbstractValidator<RemoveInvoiceRequest>
    {
        
        public RemoveInvoiceRequestValidator(IValidatorHelper validator)
        {
            
            RuleFor(x => x.InvoiceId)
                .Must(validator.Exist<Invoice>)
                .WithMessage(ErrorType.NotFound);
        }
    }
}
