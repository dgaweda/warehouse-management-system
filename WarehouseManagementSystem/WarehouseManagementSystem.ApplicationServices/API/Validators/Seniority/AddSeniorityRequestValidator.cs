using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Seniority
{
    public class AddSeniorityRequestValidator : AbstractValidator<AddSeniorityRequest>
    {
        public AddSeniorityRequestValidator()
        {
            
        }
    }
}
