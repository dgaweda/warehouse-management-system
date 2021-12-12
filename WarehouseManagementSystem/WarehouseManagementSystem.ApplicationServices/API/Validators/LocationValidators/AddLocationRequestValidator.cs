using DataAccess;
using DataAccess.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class AddLocationRequestValidator : AbstractValidator<AddLocationRequest>
    {

        private readonly ICustomValidator _validator;
        public AddLocationRequestValidator(ICustomValidator validator)
        {
            _validator = validator;

            RuleFor(x => x.Name).Must(_validator.CheckIfLocationNameIsNotTaken).WithMessage(x => $"Location named: {x.Name} already exists.");
            RuleFor(x => x.Name).Must(MatchLocationPattern).WithMessage("Name is invalid. Example location: Z.01-02");

            RuleFor(x => x.MaxAmount).ExclusiveBetween(1, 999);
            RuleFor(x => x.MaxAmount).NotEmpty().WithMessage("Max amount can't be empty");

            RuleFor(x => x.ProductId).Must(_validator.CheckIfProductExists).WithMessage("Product doesn't exists");
        }

        private bool MatchLocationPattern(string name)
        {
            Regex pattern = new("[A - Z][.][0][1 - 4] -[0][1 - 4]");
            if (pattern.IsMatch(name))
                return true;

            return false;
        }
    }
}
