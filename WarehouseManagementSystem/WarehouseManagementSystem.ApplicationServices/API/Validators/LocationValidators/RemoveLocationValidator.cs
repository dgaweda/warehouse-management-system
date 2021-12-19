using DataAccess;
using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.LocationValidators
{
    public class RemoveLocationValidator : AbstractValidator<RemoveLocationRequest>
    {
        private readonly IValidatorHelper<Location> _validator;

        public RemoveLocationValidator(IValidatorHelper<Location> validator)
        {
            _validator = validator;
            RuleFor(x => x.Id).Must(_validator.CheckIfExist).WithMessage("Location doesn't exists");
        }
    }
}
