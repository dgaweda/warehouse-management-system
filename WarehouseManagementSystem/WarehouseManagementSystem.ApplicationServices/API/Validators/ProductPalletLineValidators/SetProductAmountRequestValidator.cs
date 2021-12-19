﻿using DataAccess;
using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.ProductPalletLine
{
    public class SetProductAmountRequestValidator : AbstractValidator<SetProductAmountRequest>
    {
        private readonly IValidatorHelper<Product> _validator;
        public SetProductAmountRequestValidator(IValidatorHelper<Product> validator)
        {
            _validator = validator;
            RuleFor(x => x.PalletId).NotEmpty().WithMessage("This field must be filled");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product id must be filled");
            RuleFor(x => x.ProductAmount).GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PalletId).Must(_validator.CheckIfPalletForUnfoldingExist).WithMessage("Pallet doesn't exist.");
            RuleFor(x => x.ProductId).Must(_validator.CheckIfProductIsOnPalletForUnfolding).WithMessage("Product doesn't exist.");
        }
    }
}
