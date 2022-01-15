using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority
{
    public class AddSeniorityRequest : IRequest<AddSeniorityResponse>
    {
        public DateTime EmploymentDate { get; set; }
        public int UserId { get; set; }
    }
}
