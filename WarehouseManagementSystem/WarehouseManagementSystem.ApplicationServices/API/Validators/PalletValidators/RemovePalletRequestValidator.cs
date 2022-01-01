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
    public class RemovePalletRequestValidator : AbstractValidator<RemovePalletRequest>
    {
        readonly IValidatorHelper<Pallet> _validator;

        public RemovePalletRequestValidator(IValidatorHelper<Pallet> validator)
        {
            _validator = validator;
            RuleFor(x => x.PalletId).Must(_validator.CheckIfExist).WithMessage("Pallet not exist.");
        }
    }
}
