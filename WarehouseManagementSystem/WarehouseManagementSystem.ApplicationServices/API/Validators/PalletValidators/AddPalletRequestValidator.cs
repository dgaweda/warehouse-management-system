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
    public class AddPalletRequestValidator : AbstractValidator<AddPalletRequest>
    {
        IValidatorHelper<Pallet> _palletValidatorHelper;
        IValidatorHelper<Departure> _validatorHelper;

        public AddPalletRequestValidator(IValidatorHelper<Pallet> palletValidatorHelper, IValidatorHelper<Departure> validatorHelper)
        {
            _palletValidatorHelper = palletValidatorHelper;
            _validatorHelper = validatorHelper;
            RuleFor(x => x.Barcode).Must(_palletValidatorHelper.CheckIfPalletBarcodeIsUnique).WithMessage(x => $"Pallet with barcode: {x.Barcode} already exist.");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barcode must be filled.");
            RuleFor(x => x.OrderId).Must(_validatorHelper.CheckIfExist).WithMessage("Order not exist.");
            RuleFor(x => x.DepartureId).Must(_validatorHelper.CheckIfExist).WithMessage("Departure not exist.");
            RuleFor(x => x.InvoiceId).Must(_validatorHelper.CheckIfExist).WithMessage("Invoice not exist.");
            RuleFor(x => x.UserId).Must(_validatorHelper.CheckIfExist).WithMessage("User not exist.");
        }
    }
}
