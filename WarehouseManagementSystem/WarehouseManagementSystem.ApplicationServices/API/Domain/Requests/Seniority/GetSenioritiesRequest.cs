using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetSenioritiesRequest : UserRequestBase, IRequest<GetSenioritiesResponse>
    {
        public DateTime EmploymentDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

    }
}
