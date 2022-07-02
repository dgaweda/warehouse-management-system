using DataAccess.Entities;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class RemoveInvoiceRequestValidator : AbstractValidator<RemoveInvoiceRequest>
    {
        private readonly IValidatorHelper _validator;
        public RemoveInvoiceRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.InvoiceId)
                .Must(_validator.Exist<Invoice>)
                .WithMessage(ErrorType.NotFound);
        }
    }
}
