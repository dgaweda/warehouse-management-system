using DataAccess.Entities;
using FluentValidation;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public class GetInvoiceRequestValidator : AbstractValidator<GetInvoicesRequest>
    {
        private readonly IValidatorHelper _validator;
        public GetInvoiceRequestValidator(IValidatorHelper validator)
        {
            _validator = validator;
            RuleFor(x => x.InvoiceNumber).Must(_validator.IsInvoiceNumberNotExist).WithMessage(ErrorType.NotFound);
        }
    }
}
