using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee
{
    public class GetEmployeeByIdRequest : IRequest<GetEmployeeByIdResponse>
    {
        public int EmployeeId { get; set; }
    }
}
