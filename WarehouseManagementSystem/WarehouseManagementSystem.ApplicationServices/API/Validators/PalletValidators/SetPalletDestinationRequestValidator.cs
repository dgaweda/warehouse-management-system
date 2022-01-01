using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.PalletValidators
{
    public class SetPalletDestinationRequestValidator : AbstractValidator<SetPalletDestinationRequest>
    {
        readonly IValidatorHelper<Pallet> _palletValidatorHelper;
        readonly IValidatorHelper<Departure> _validatorHelper;

        public SetPalletDestinationRequestValidator(IValidatorHelper<Pallet> palletValidatorHelper, IValidatorHelper<Departure> validatorHelper)
        {
            _palletValidatorHelper = palletValidatorHelper;
            _validatorHelper = validatorHelper;
            RuleFor(x => x.Id).Must(_validatorHelper.CheckIfExist).WithMessage("Pallet of that Id not exist.");
            RuleFor(x => x.OrderId).Must(_validatorHelper.CheckIfExist).WithMessage("Order not exist.");
            RuleFor(x => x.DepartureId).Must(_validatorHelper.CheckIfExist).WithMessage("Departure not exist.");
            RuleFor(x => x.InvoiceId).Must(_validatorHelper.CheckIfExist).WithMessage("Invoice not exist.");
            RuleFor(x => x.EmployeeId).Must(_validatorHelper.CheckIfExist).WithMessage("Employe not exist.");
        }
    }
}
