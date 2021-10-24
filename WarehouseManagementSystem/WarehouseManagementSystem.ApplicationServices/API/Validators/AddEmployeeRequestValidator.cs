using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators
{
    public class AddEmployeeRequestValidator : AbstractValidator<AddEmployeeRequest>
    {
        public AddEmployeeRequestValidator()
        {
            
        }
    }
}
